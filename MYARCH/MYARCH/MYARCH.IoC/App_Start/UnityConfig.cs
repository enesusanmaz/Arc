using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using MYARCH.CORE;
using MYARCH.DATA.GenericRepository;
using MYARCH.DATA.UnitofWork;
using MYARCH.SERVICES.Interfaces;
using MYARCH.SERVICES.Services;

namespace MYARCH.IoC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.BindInRequestScope<IUnitofWork, UnitofWork>();
            container.BindInRequestScope<IUserService, UserService>();
            container.BindInRequestScope<IPostService, PostService>();
            container.BindInRequestScope<ICategoryService, CategoryService>();
            container.BindInRequestScope<IGenericRepository<User>, GenericRepository<User>>();
            container.BindInRequestScope<IGenericRepository<Post>, GenericRepository<Post>>();
            container.BindInRequestScope<IGenericRepository<Category>, GenericRepository<Category>>();
        }


        public static void BindInRequestScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new HierarchicalLifetimeManager());
        }

    }
}