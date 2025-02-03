using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class VendorService
    {
        private VendorRepository repository = new VendorRepository();

        public List<Vendor> GetVendors()
        {
            return repository.GetVendors();
        }
    }
}
