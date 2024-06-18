using AutoMapper;
using BL.BlApi;
using DAL;
using DAL.DalApi;
using DAL.DalModels;

namespace BL.BlServices
{
    public class BLCutomerService : IBLCustomer
    {
        readonly IMapper mapper;
        ICustomer customerDal;
        
        public BLCutomerService(DalManager bl, IMapper mapper)
        {
            this.customerDal = bl.Customer;
            this.mapper = mapper;
        }
        public bool Type(string id)
        {
            if (getALLDetails(id)!=null) { return true; }
            return false;
        }
        public bool addNewCustomer(BLCustomer customer)
        {
            Customer customer1 = mapper.Map<Customer>(customer);
            if (customer1 == null) { return false; }
            customerDal.addCustomer(customer1);
            return true;
        }

        public bool deleteCustomer(string id)
        {
            var c= customerDal.removeCustomer(id);
            if(c)return true;
            return false;
        }

        public Customer getALLDetails(string id)
        {
           var c= customerDal.getALLDetails(id);
            return c;
        }

        public Customer updateDetailsCustomer(BLCustomer customer)
        {
            Customer customer1 = mapper.Map<Customer>(customer);
            customerDal.updateCustomer(customer1);
            return customer1;
        }
    }
}
