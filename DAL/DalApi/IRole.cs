using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IRole
    {
        public List<Role> getRoleById(string id);
        public Role updateRole(Role role);
        public bool removeRole(string id);
        public bool addRole(Role role);


    }
}
