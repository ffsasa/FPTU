using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class VendorRepository
    {
        ConvenienceStoreDbContext dbContext;

        public List<Vendor> GetVendors()
        {
            dbContext = new ConvenienceStoreDbContext();
            return dbContext.Vendors.ToList();
        }
    }
}
