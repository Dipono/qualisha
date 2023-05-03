using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qualisha.iCommunity.Data.Models
{
    /// <summary>
    /// This Class is for Address
    /// </summary>
    public class Address
    {
        public Address()
        {
            Line1 = string.Empty;
            Province = string.Empty;
            City = string.Empty;
            Suburb = string.Empty;
            Estate = string.Empty;
            Code = string.Empty;
        }

        public int Id { get; set; }

        [MinLength(3), MaxLength(255)]
        public string Line1 { get; set; }

        [MinLength(3), MaxLength(255)]
        public string? Line2 { get; set; }

        [MinLength(3), MaxLength(255)]
        public string Province { get; set; }

        [MinLength(3), MaxLength(255)]
        public string City { get; set; }

        [MinLength(3), MaxLength(255)]
        public string Suburb { get; set; }

        [MinLength(3), MaxLength(255)]
        public string Estate { get; set; }

        [MinLength(3), MaxLength(255)]
        public string Code { get; set; }
    }
}