using System.ComponentModel.DataAnnotations;

namespace WebChat.ViewModels.Account
{
    public class RegisterVM
    {
        [Required]
        [MinLength(3)]

        public string Username { get; set; }
        [Required]
        [MinLength(3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password")]
        [MinLength(3)]
        [DataType(DataType.Password)]
        public string ConfimPwd { get; set; }


        [Required]
        public string DisplayName { get; set; }
    }
}
