using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTechECommerceAPI.Helpers
{

    public class Orders
    {

        public int createOrder(Models.CreateOrderReq obj)
        {

            try
            {
                EFModels.NTECommerceDBContext context = new EFModels.NTECommerceDBContext();
                var result = context.Orders
                          .FromSqlRaw($"EXEC CreateOrder {obj.CustomerId}, {obj.ItemId}, {obj.AddressId}, {obj.Quantity}")
                          .ToList();

                return result.FirstOrDefault().Id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            

        }

        public List<EFModels.Order> getOrders(int pageIndex, int pageSize)
        {

            List<EFModels.Order> data = new List<EFModels.Order>();

            try
            {
                EFModels.NTECommerceDBContext context = new EFModels.NTECommerceDBContext();
                var result = context.Orders
                          .FromSqlRaw("EXEC GetOrders " + pageIndex + ", " + pageSize)
                          .ToList();

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

    }

}
