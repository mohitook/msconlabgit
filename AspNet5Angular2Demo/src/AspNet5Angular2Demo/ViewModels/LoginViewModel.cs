using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5Angular2Demo.ViewModels
{
    public class LoginViewModel
    {
        
        //[Required]
        [Display(Name = "Username")] //az input mező feletti label-t tölti fel
        public string Username { get; set; }
       // [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
