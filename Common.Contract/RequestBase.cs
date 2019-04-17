using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contract.Base
{
    public abstract class RequestBase
    {
        public RequestHeader Header { get; set; }
    }
}
