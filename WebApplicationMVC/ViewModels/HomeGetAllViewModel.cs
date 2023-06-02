using WebApplicationMVC.Models;

namespace WebApplicationMVC.ViewModels
{
    public class HomeGetAllViewModel
    {
        public IEnumerable<Staff> Staffs { get; set; }
    }
}
