using DAL.DalApi;
using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    internal class RoleService : IRole
    {
        private StudioContext studioContext;
        public RoleService(StudioContext context)
        {
            this.studioContext = context;
        }

        public bool addRole(Role role)
        {
            if(role == null) { return false; }
            studioContext.Roles.Add(role);
            return true;
        }

        public List<Role> getRoleById(string id)
        {
            List<Role> role = new List<Role>();
            foreach (var r in studioContext.Roles)
            {
                if (r.Id == id) { role.Add(r); }
            }
            return role;

        }

        public bool removeRole(string id)
        {
            var r = studioContext.Roles.FirstOrDefault(r =>r.Id.Equals(id));
            if (r != null) { studioContext.Roles.Remove(r); return true; }
            return false;

        }

        public Role updateRole(Role role)
        {
            var r = studioContext.Roles.FirstOrDefault(c => c.Id.Equals(role.Id));
            if (r == null) return null;
            r.WorkerId = role.WorkerId;
            r.Type = role.Type;
            studioContext.SaveChanges();
            return r;
        }
    }
}
