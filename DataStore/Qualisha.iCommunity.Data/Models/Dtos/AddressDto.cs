using System.ComponentModel.DataAnnotations;

namespace Qualisha.iCommunity.Data.Models.Dtos
{
    public class AddressDto
    {
        public AddressDto()
        {
            Line1 = string.Empty;
            Province = string.Empty;
            City = string.Empty;
            Suburb = string.Empty;
            Estate = string.Empty;
            Code = string.Empty;
        }

        public int Id { get; set; }

        [Display(Name = "Line1")]
        [Required(ErrorMessage = "Line 1 is Required")]
        [MinLength(3), MaxLength(255)]
        public string Line1 { get; set; }

        [Display(Name = "Line2")]
        [MinLength(3), MaxLength(255)]
        public string? Line2 { get; set; }

        [Display(Name = "Province")]
        [Required(ErrorMessage = "Province is Required")]
        [MinLength(3), MaxLength(255)]
        public string Province { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is Required")]
        [MinLength(3), MaxLength(255)]
        public string City { get; set; }

        [Display(Name = "Suburb")]
        [Required(ErrorMessage = "Suburb is Required")]
        [MinLength(3), MaxLength(255)]
        public string Suburb { get; set; }

        [Display(Name = "Estate")]
        [Required(ErrorMessage = "Estate is Required")]
        [MinLength(3), MaxLength(255)]
        public string Estate { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "Postal Code is Required")]
        [DataType(DataType.PostalCode)]
        [MinLength(3), MaxLength(255)]
        public string Code { get; set; }
    }
}