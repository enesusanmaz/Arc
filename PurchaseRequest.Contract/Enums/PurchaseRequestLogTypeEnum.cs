using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PurchaseRequest.Contract.Enums
{
    public enum PurchaseRequestLogTypeEnum
    {
        Create = 1,
        Update = 2,
        Send = 3,
        Approve = 4,
        Reject = 5,
        Cancel = 6,
        Complete = 7,
        LineReject = 8,
        LineCancel = 9,
        LineAdd = 10,
        LineUpdate = 11
    }
}
