using Common.Contract.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseRequest.Contract.Request
{
   public class DeletePurchaseRequestRequest  : RequestBase
    {
        public int PurchaseRequestId { get; set; }
    }
}
