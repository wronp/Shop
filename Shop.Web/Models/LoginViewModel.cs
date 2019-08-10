using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        [MinLength(3)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
