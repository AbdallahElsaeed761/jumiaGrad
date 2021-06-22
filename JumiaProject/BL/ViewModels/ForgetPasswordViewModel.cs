using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    class ForgetPasswordViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
