using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlApi
{
    internal interface IBLRole
    {
        public List<Role> getDetailsById(string id);
        public Role updateDetailsRole(BLRole role);
        public bool deleteRole(string id);
        public bool addNewRole(BLRole role);

    }
}
