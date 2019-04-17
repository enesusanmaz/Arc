using Common.Contract.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseRequest.Contract.Response
{
    public class CancelPurchaseRequestResponse : ResponseBase
    {
        public int CancelledPurchaseRequestId { get; set; }
    }
}
