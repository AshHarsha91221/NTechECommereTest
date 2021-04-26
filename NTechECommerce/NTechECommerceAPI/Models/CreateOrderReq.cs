using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTechECommerceAPI.Models
{
    public class CreateOrderReq
    {
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public int AddressId { get; set; }
        public int Quantity { get; set; }
    }
}
