
using Common.Contract.Base;
using System.Threading.Tasks;

namespace Prosource.Handler
{
    public interface IPipeLinePreRequestHandler
    {
        Task PreRequest(string serviceName, RequestBase request);
    }
}
