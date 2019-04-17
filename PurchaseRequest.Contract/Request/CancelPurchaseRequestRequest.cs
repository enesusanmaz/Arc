
using Common.Contract.Base;
using PurchaseRequest.Contract;
using PurchaseRequest.Contract.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseRequest.Contract.Request
{
    public class CancelPurchaseRequestRequest : RequestBase
    {
        public int PurchaseRequestID { get; set; }
    }
}
