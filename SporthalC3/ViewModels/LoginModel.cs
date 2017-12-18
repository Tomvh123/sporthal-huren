using System.ComponentModel.DataAnnotations;
using SporthalC3.Models;


namespace SporthalC3.ViewModels
{

    public class LoginModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
