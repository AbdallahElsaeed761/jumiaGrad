using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }




        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
    public class RegisterSellerViewModel:RegisterViewModel
    {
        [Required]
        [RegularExpression("^01[0125][0-9]{8}$")]
        public string PhoneNumber { get; set; }
        
        


        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string StoreName { get; set; }

    }
    public class RegisterEmployeeViewModel:RegisterViewModel
    {
        public DateTime HireDate { get; set; } = DateTime.Now;
        [Required]
        public double Salary { get; set; }
    }
}
