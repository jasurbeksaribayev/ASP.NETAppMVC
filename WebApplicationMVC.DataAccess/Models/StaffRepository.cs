using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMVC.DataAccess.Contexts;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.DataAccess.Models
{
    public class StaffRepository : IStaffRepository
    {
        private readonly WebApplicationMVCDbContext dbContext;

        public StaffRepository(WebApplicationMVCDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Staff Create(Staff staff)
        {
            dbContext.Staffs.Add(staff);
            dbContext.SaveChanges();
            return staff;
        }

        public Staff Delete(int id)
        {
            var deletedStaff = Get(id);
            if(deletedStaff is not null)
            {
                dbContext.Staffs.Remove(deletedStaff);
                dbContext.SaveChanges();
            }
            return deletedStaff;
        }

        public Staff Get(int id)
            => dbContext.Staffs.FirstOrDefault(s => s.Id.Equals(id));


        public IEnumerable<Staff> GetAll()
            => dbContext.Staffs;

        public Staff Update(Staff staff)
        {
            var existStaff = Get(staff.Id);
            if(existStaff is not null)
            {
                var updatedstaff = dbContext.Staffs.Attach(staff);
                updatedstaff.State = EntityState.Modified;
                dbContext.SaveChanges();
                return staff;
            }
            return null;
        }
    }
}
