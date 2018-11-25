using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HelpModel
{
   public class LoginUser
    {
        [Required]
        [MinLength(64),MaxLength(64)]
        public string Password { get; set; }
        [Required]
        [MinLength(2), MaxLength(15)]
        public string UserName { get; set; }
    }
}
