using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class Staff
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Firstname")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Lastname")] 
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
