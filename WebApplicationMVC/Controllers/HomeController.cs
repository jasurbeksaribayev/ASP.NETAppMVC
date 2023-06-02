using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;
using WebApplicationMVC.ViewModels;

namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStaffRepository staffRepository;
        public HomeController(ILogger<HomeController> logger , IStaffRepository staffRepository)
        {
            _logger = logger;
            this.staffRepository = staffRepository;
        }
        public IActionResult Index()
        {
            HomeGetAllViewModel viewModel = new HomeGetAllViewModel()
            {
                Staffs = staffRepository.GetAll()
            };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            var viewModel = new HomeDetailsViewModel()
            {
                Staff = staffRepository.Get(id ?? 1),
                Title = "Staff details"
            };
            return View(viewModel);
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Staff staff)
        {
            var newStaff = staffRepository.Create(staff);
            return RedirectToAction("Details",new {id = newStaff.Id});
        }
        
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}