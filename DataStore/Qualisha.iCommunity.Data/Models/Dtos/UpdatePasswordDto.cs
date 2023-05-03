using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.Data.Models.Dtos
{
    public class UpdatePasswordDto
    {
        public UpdatePasswordDto()
        {
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }
        [Display(Name = "Password")]
        [MinLength(8), MaxLength(255)]
        [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$",
             ErrorMessage = "Minimum 8 characters \n Should have at least one number \n Should have at least one upper case \n Should have at least one lower case \n Should have at least one special character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Comfirm Password")]
        [Compare("Password", ErrorMessage = "Comfirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public int UserId { get; set; }
    }
}
