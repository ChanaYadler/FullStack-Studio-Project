using DAL.DalApi;
using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    internal class CustomerService : ICustomer
    {
        private StudioContext studioContext;
        public CustomerService(StudioContext context)
        {
            studioContext = context;
        }
        public bool addCustomer(Customer customer)
        {
            if (customer == null) { return false; }
            studioContext.Customers.Add(customer);return true;
        }

        public bool removeCustomer(string id)
        {
            var s = studioContext.Customers.FirstOrDefault(m => m.Id.Equals(id));
            if (s != null)
            {
                studioContext.Customers.Remove(s);
                return true;
            }return false;
        }

        public Customer getALLDetails(string id)
        {
            var s = studioContext.Customers.FirstOrDefault(m => m.Id.Equals(id));
            if (s != null) { return s; }
            return null;
        }

        public Customer updateCustomer(Customer customer)
        {
            var c = studioContext.Customers.FirstOrDefault(c => c.Id.Equals(customer.Id));
            if (c == null) return null;
            c.PhoneNumber = customer.PhoneNumber;
            c.LastName = customer.LastName;
            c.FirstName = customer.FirstName;
            c.Meetings = customer.Meetings;
            studioContext.SaveChanges();
            return c;
        }
    }
}
