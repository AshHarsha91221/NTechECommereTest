using System;
using System.Collections.Generic;

#nullable disable

namespace NTechECommerceAPI.EFModels
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public int AddressId { get; set; }
        public int Quantity { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Customer CreatedByNavigation { get; set; }
    }
}
