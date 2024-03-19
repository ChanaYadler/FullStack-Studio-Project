using AutoMapper;
using BL.BlApi;
using DAL.DalApi;
using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlServices
{
    internal class BLRoleService : IBLRole
    {
        readonly IMapper mapper;
        IRole RoleDAL;

        public BLRoleService(IRole RoleBL, IMapper mapper)
        {
            this.RoleDAL = RoleBL;
            this.mapper = mapper;
        }
        public bool addNewRole(BLRole role)
        {
            Role role1 = mapper.Map<Role>(role);
            var r =RoleDAL.addRole(role1); 
            if(r) return true;
            return false;
        }

        public bool deleteRole(string id)
        {
            var r= RoleDAL.removeRole(id);
            if(r) return true;
            return false;
        }

        public List<Role> getDetailsById(string id)
        {
            var r= RoleDAL.getRoleById(id);
            return r;
        }

        public Role updateDetailsRole(BLRole role)
        {
            Role role1 = mapper.Map<Role>(role);
            RoleDAL.updateRole(role1);
            return role1;
        }
    }
}
