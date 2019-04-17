using Common.Contract.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contract
{
    public class TableDataResponse<T> : ResponseBase
    {
        public int Total { get; set; }
        public IList<T> ListData { get; set; }
    }
}
