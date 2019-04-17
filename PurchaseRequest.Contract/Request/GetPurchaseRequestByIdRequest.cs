using Common.Contract.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseRequest.Contract.Request
{
    public class GetPurchaseRequestByIdRequest : RequestBase
    {
        public int RequestId { get; set; }
    }
}
