namespace WebApplicationMVC.Models
{
    public class MockStaffRepository : IStaffRepository
    {
        private List<Staff> staffs = null;

        public MockStaffRepository()
        {
            staffs = new List<Staff>() 
            {
                new Staff(){Id=1,FirstName="Jasur",LastName="Saribayev",Email= "jasurbek1009@gmail.com"},
                new Staff(){Id=2,FirstName="Jamshid",LastName="Saribayev",Email= "Jamshidbek1009@gmail.com"},
                new Staff(){Id=3,FirstName="Umarbek",LastName="Kanalbekov",Email= "Umarbek1009@gmail.com"}
            };
        }

        public Staff Create(Staff staff)
        {
            staff.Id = staffs.Max(s => s.Id) +1;
            staffs.Add(staff);
            return staff;
        }

        public Staff Delete(int id)
        {
            var existStaff = Get(id);
            if(existStaff is not null)
            {
                staffs.Remove(existStaff);
            }
            return existStaff;
        }

        public Staff Get(int id)
        {
            return staffs.FirstOrDefault(s => s.Id.Equals(id));
        }
        public IEnumerable<Staff> GetAll()
        {
            return staffs;
        }

        public Staff Update(Staff staff)
        {
            var existStaff = Get(staff.Id);
            if(existStaff is not null)
            {
                existStaff.FirstName = staff.FirstName;
                existStaff.LastName = staff.LastName;
                existStaff.Email = staff.Email;
                return existStaff;
            }
            return null;
        }
    }
}
