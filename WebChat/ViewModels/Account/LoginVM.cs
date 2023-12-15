using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace WebChat.ViewModels.Account
{
    public class LoginVM
    {
       // [Required]
        [MinLength(3)]
        public string Username { get; set; }
       //b [Required]
        [MinLength(4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
       /* public string DisplayName { get; set; }*/
    }
}
