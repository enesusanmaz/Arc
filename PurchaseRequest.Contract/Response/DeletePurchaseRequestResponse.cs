using Common.Contract.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseRequest.Contract.Response
{
  public  class DeletePurchaseRequestResponse : ResponseBase
    {
        public bool Result { get; set; }
    }
}
