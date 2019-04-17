namespace PurchaseRequest.Contract.Enums
{
    public enum PurchaseRequestStatusEnum
    {
        None = 0,//hiçbiri-db'de yok
        New = 1,//kurulumda
        PendingConfirmation = 2,//onay bekliyor
        InPurchase = 3,//satın almada,
        Rejected = 4,//reddedildi
        Completed = 5,//tamamlandı
        Cancel = 6
    }
}
