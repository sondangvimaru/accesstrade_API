using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class LoginModel
    {
        [Required]
        [MaxLength(150)]
        public string? Username { get; set; }
        [Required]
        [MaxLength(150)]
        public string? Password { get; set; }
    }
}
