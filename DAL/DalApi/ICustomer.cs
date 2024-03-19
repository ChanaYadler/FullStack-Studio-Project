using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface ICustomer
    {
        public Customer getALLDetails(string id);
        public bool addCustomer(Customer customer);
        public Customer updateCustomer(Customer customer);
        public bool removeCustomer(string id);

        


    }
}
