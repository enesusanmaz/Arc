using Common.Contract.Base;
using PurchaseRequest.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseRequest.Contract.Request
{
    public class CreatePurchaseRequestRequest : RequestBase
    {
        public PurchaseRequestDTO Data { get; set; }
    }
}
