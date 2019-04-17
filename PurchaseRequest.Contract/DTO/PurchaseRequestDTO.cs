using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseRequest.Contract.DTO
{
    public class PurchaseRequestDTO
    {
        public int RequestId { get; set; }
        public string RequestIdWithPrefix { get; set; }
        public string Title { get; set; }
        public int RequestStatusId { get; set; }
        public string RequestStatusName { get; set; }
        public int DepartmentOrgUnitId { get; set; }
        public string DepartmentOrgUnitName { get; set; }
        public int CurrencyTypeId { get; set; }
        public string CurrencyTypeText { get; set; }

        public string BillToAddressTitle { get; set; }
        public int? CostCenterId { get; set; }
        public string CostCenterCode { get; set; }

        public string CostCenter { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByFullName { get; set; }

        public string CreatedByTelNo { get; set; }
        public string CreatedByEmail { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BuyerId { get; set; }

        public string CurrencyTypeName { get; set; }

        public int ShipToAddressId { get; set; }
        public string ShipToAddressName { get; set; }

        public string ShipToAddress { get; set; }
        public int BillToAddressId { get; set; }
        public string BillToAddressName { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
        public string SupplierNote { get; set; }

        public string ShipToPerson { get; set; }
        public string BillToPerson { get; set; }


        public int? ModifiedBy { get; set; }
        public string ModifiedByFullName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int? CopyFromPurchaseRequestID { get; set; }

        public DateTime? DeliveryDate { get; set; }


        public int CompanyOrgUnitId { get; set; }
        public string CompanyOrgUnitName { get; set; }
        public decimal TotalAmount { get; set; }

        public int CreatorId { get; set; }
        public int CreatorLanguageId { get; set; }
        public int CreatorTimeZoneId { get; set; }
        public string CreatorFullName { get; set; }
        public string CreatorUsername { get; set; }
        public string BuyerUsername { get; set; }

    }
}
