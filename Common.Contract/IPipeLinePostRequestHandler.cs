using Common.Contract.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prosource.Handler
{
    public interface IPipeLinePostRequestHandler
    {
        Task PostRequest(string serviceName, RequestBase request, ResponseBase response);
    }
}
