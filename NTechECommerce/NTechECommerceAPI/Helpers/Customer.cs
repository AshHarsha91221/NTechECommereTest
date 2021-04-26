using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTechECommerceAPI.Helpers
{
    public class Customer
    {

        public int createUpdateCustomer(Models.CreateUpdateCustomerReq obj)
        {

            try
            {
                EFModels.NTECommerceDBContext context = new EFModels.NTECommerceDBContext();
                var result = context.Customers
                          .FromSqlRaw($"EXEC CreateUpdateCustomer {obj.Id}, '{obj.FirstName}', '{obj.LastName}', '{obj.EmailAddress}', '{obj.Password}', '{obj.PhoneNumber}'")
                          .ToList();

                return result.FirstOrDefault().Id;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

    }
}
