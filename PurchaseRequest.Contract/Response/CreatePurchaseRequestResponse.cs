using Common.Contract.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseRequest.Contract.Response
{
    public class CreatePurchaseRequestResponse : ResponseBase
    {
        public int PurchaseRequestId { get; set; }
    }
}
