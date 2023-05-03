using Qualisha.iCommunity.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qualisha.iCommunity.RegistrationAPI.Model
{
    public class User
    {
        public int Id { get; set; }

        [MinLength(3), MaxLength(255)]
        public string FirstName { get; set; }

        [MinLength(3), MaxLength(255)]
        public string LastName { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Address Address { get; set; }

        [MinLength(8), MaxLength(255)]
        public string EmailAddress { get; set; }

        [MinLength(8), MaxLength(255)]
        public string Password { get; set; }

        [MinLength(10), MaxLength(13)]
        public string? PhoneNumber { get; set; }

        public bool Active { get; set; }

        /// <summary>
        /// Innitialise the user object
        /// </summary>
        public User()
        {
            EmailAddress = string.Empty;
            Password = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Address = new Address();
        }
    }
}