using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contract.Base
{
    public interface IService<TRequest, TResponse>
        where TRequest : RequestBase
        where TResponse : ResponseBase
    {
        TResponse Execute(TRequest request);
    }
}
