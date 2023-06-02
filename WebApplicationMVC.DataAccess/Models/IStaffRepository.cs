namespace WebApplicationMVC.Models
{
    public interface IStaffRepository
    {
        Staff Get(int id);
        IEnumerable<Staff> GetAll();
        Staff Create(Staff staff);
        Staff Delete(int id);
        Staff Update(Staff staff);
    }
}
