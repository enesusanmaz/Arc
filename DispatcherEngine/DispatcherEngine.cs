using Common.Contract.Base;
using Newtonsoft.Json;
using Prosource.Handler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;


namespace Dispatcher
{
    public class DispatcherEngine
    {
        private class Service
        {
            public string Key { get; set; }
            public object ServiceObject { get; set; }
            public MethodInfo ExcecuteMethodInfo { get; set; }

            public object Invoke(object request)
            {
                return this.ExcecuteMethodInfo.Invoke(this.ServiceObject, new object[] { request });
            }
        }

        private const string rootAddress = "Root";

        private static Lazy<DispatcherEngine> _current = new Lazy<DispatcherEngine>(() => new DispatcherEngine(), true);

        public static DispatcherEngine Current { get { return _current.Value; } }

        public List<IPipeLinePostRequestHandler> PipeLinePostRequestHandler { get; }

        public List<IPipeLinePreRequestHandler> PipeLinePreRequestHandler { get; }

        private Lazy<Assembly[]> assemblies = new Lazy<Assembly[]>(() =>
        {
            var rootPath = AppContext.BaseDirectory;

            return Directory.GetFiles(rootPath, "*.dll").Select(c => Assembly.LoadFrom(c)).ToArray();
        }, true);

        public Assembly[] Assemblies
        {
            get
            {
                return this.assemblies.Value;
            }
        }
        // TODO: Convert type to ConcurrentDictionary.
        Hashtable _services = Hashtable.Synchronized(new Hashtable(new Dictionary<string, Service>()));

        public DispatcherEngine()
        {
            this.PipeLinePostRequestHandler = new List<IPipeLinePostRequestHandler>();
            this.PipeLinePreRequestHandler = new List<IPipeLinePreRequestHandler>();
        }

        //For internal usage
        public TResponse Execute<TRequest, TResponse>(TRequest request)
            where TRequest : RequestBase
            where TResponse : ResponseBase
        {
            var actionName = GetTargetActionNameByRequestType(typeof(TRequest));
            var service = GenerateServiceInstance(actionName);

            foreach (var item in this.PipeLinePreRequestHandler)
            {
                item.PreRequest(actionName, request);
            }

            var result = service.Invoke(request);

            foreach (var item in this.PipeLinePostRequestHandler)
            {
                item.PostRequest(actionName, request, (TResponse)result);
            }

            return (TResponse)result;
        }

        private string GetTargetActionNameByRequestType(Type requestType)
        {
            return requestType.Name.Substring(0, requestType.Name.LastIndexOf("Request"));
        }

        public string Execute(string actionPath, string requestBody = "")
        {
            var targetActionName = GetTargetActionNameByPath(actionPath);

            if (targetActionName == rootAddress)
            {
                return "Hello World!";
            }

            var service = GenerateServiceInstance(targetActionName);
            var targetTypeContract = service.ServiceObject.GetType().GetInterface("IService`2");

            var inputType = targetTypeContract.GenericTypeArguments[0];
            var param = JsonConvert.DeserializeObject(requestBody, inputType);            
            var result = service.Invoke(param);

            return JsonConvert.SerializeObject(result);
        }

        private Service GenerateServiceInstance(string actionName)
        {
            if (this._services.ContainsKey(actionName))
            {
                return (Service)this._services[actionName];
            }

            lock (this._services.SyncRoot)
            {
                if (this._services.ContainsKey(actionName))
                {
                    return (Service)this._services[actionName];
                }

                Type serviceType = this.Assemblies
                    .Select(c => c.GetType($"{GetAssemblyName(c.FullName)}.{actionName}Service", ignoreCase: true, throwOnError: false))
                    .FirstOrDefault(c => c != null);

                if (serviceType is null)
                {
                    throw new Exception("Target end-point couldn't be found.");
                }

                var executeMethodInfo = serviceType.GetMethod("Execute");

                if (executeMethodInfo == null || executeMethodInfo.GetParameters().Count() != 1)
                {
                    throw new Exception("service Execute method not found");
                }

                var serviceInstance = Activator.CreateInstance(serviceType);

                this._services[actionName] = new Service
                {
                    Key = actionName,
                    ServiceObject = serviceInstance,
                    ExcecuteMethodInfo = executeMethodInfo
                };

                return (Service)this._services[actionName];
            }
        }

        internal string GetAssemblyName(string assemblyFullName)
        {
            return assemblyFullName.Substring(0, assemblyFullName.IndexOf(','));
        }

        internal string GetTargetActionNameByPath(string actionPath)
        {
            var actionName = "";
            if (actionPath.Equals("/"))
                actionName = rootAddress;
            else if (string.IsNullOrWhiteSpace(actionPath))
                return actionName;
            else
            {
                var startIndex = actionPath[0] == '/' ? 1 : 0;
                var IndexOfSeperator = actionPath.Substring(startIndex).IndexOf("/");
                actionName = IndexOfSeperator < 1 ? actionPath.Substring(startIndex) : actionPath.Substring(startIndex, actionPath.Substring(startIndex).IndexOf("/"));
            }

            return actionName;
        }
    }
}
