﻿using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlApi
{
    internal interface IBLCustomer
    {
        public Customer getALLDetails(string id);
        public bool addNewCustomer(BLCustomer customer);
        public Customer updateDetailsCustomer(BLCustomer customer);
        public bool deleteCustomer(string id);

    }
}