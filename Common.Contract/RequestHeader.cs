using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contract.Base
{
    public sealed class RequestHeader : Header
    {
        public string ClientName { get; set; }
        public int UserId { get; set; }
        public int? BuyerId { get; set; }
        public int? SupplierId { get; set; }
        public string Username { get; set; }
        public int LanguageId { get; set; }
        public string SelectedTimeZone { get; set; }
        public int? BuyerOrgUnitId { get; set; }
      
    }
}
