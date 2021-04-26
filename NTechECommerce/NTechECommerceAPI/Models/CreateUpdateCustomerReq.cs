using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTechECommerceAPI.Models
{
    public class CreateUpdateCustomerReq
    {

		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; }

	}
}
