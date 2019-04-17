using Common.Contract.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseRequest.Contract.Response
{
    public class GetPurchaseRequestByIdResponse : ResponseBase
    {
        public DTO.PurchaseRequestDTO Data { get; set; }
    }
}
