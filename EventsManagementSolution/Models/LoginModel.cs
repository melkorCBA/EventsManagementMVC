using System.ComponentModel.DataAnnotations;

namespace EventsManagementSolution.Controllers
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}