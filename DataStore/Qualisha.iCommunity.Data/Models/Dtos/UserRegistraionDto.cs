using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qualisha.iCommunity.Data.Models.Dtos
{
    public class UserRegistraionDto
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [MinLength(3), MaxLength(255)]
        [Required(ErrorMessage = "Name is Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MinLength(3), MaxLength(255)]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [ForeignKey("AddressDto")]
        public int AddressId { get; set; }

        public AddressDto AddressDto { get; set; }

        [Display(Name = "Email Address")]
        [MinLength(8), MaxLength(255)]
        [Required(ErrorMessage = "Email Address is Required")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

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
        public string? ConfirmPassword { get; set; }

        [Display(Name = "Cell Phone Number")]
        [MinLength(10), MaxLength(13)]
        public string? PhoneNumber { get; set; }

        public bool Active { get; set; }


        public UserRegistraionDto()
        {
            EmailAddress = string.Empty;
            Password = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            AddressDto = new AddressDto();
        }
    }
}