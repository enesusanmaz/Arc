using Common.Contract.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contract
{
    public class TableDataRequest: RequestBase
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public string SortColumn { get; set; }
        public bool IsAscending { get; set; }
        public string SearchText { get; set; }
    }
}
