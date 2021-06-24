using BL.StatisClass;
using DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reporsities
{
   public class RoleRepository:Basices.BaseRepository<IdentityRole>
    {
        ApplicationRoleManager manager;
        public RoleRepository(DbContext dbcontext):base(dbcontext)
            
        {
            manager = new ApplicationRoleManager();
        }
        public IdentityRole GetRoleByID(string id)
        {
            return GetFirstOrDefault(r => r.Id == id);
        }
        public async Task CreateRoles()
        {

            if (!await manager.RoleExistsAsync(UserRoles.Admin))
                await manager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await manager.RoleExistsAsync(UserRoles.Customer))
                await manager.CreateAsync(new IdentityRole(UserRoles.Customer));
            if (!await manager.RoleExistsAsync(UserRoles.Seller))
                await manager.CreateAsync(new IdentityRole(UserRoles.Seller));
            if (!await manager.RoleExistsAsync(UserRoles.Employee))
                await manager.CreateAsync(new IdentityRole(UserRoles.Employee));

        }

        public IdentityResult Create(string role)
        {
           
            return manager.CreateAsync(new IdentityRole(role)).Result;

        }
        public IdentityResult UpdateRole(IdentityRole role)
        {
            var identityRole = manager.FindById(role.Id);
            identityRole.Name = role.Name;
            return manager.Update(identityRole);
        }
        public void DeleteRole(string id)
        {
            var identityRole = manager.FindById(id);

            manager.Delete(identityRole);
        }
        public List<IdentityRole> getAllRoles()
        {
            return GetAll().Include(r => r.Users).ToList();
        }
    }
}
