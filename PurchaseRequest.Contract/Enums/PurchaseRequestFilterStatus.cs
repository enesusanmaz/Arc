using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseRequest.Contract.Enums
{
    public enum PurchaseRequestFilterStatus : int
    {
        /// <summary>
        ///  1.	İşlem Bekleyen ( Default) RFQ veya Sipariş oluşmadıysa ve Satır İptal değil veya Talep iptal değilse..
        /// </summary>
        Pending = 1,
        /// <summary>
        ///  2.	İşlem Yapılan: RFQ veya Sipariş oluştuysa
        /// </summary>
        Processed = 2,
        /// <summary>
        /// 3.	İptal : Satır İptal (REQLine.IsCancelled) veya REQ.Status = Canceled       Yeni eklenen Filtre alanını Eskiden olan Durum alanı yerine ekliyoruz.
        /// </summary>
        Cancelled = 3
    }
}
