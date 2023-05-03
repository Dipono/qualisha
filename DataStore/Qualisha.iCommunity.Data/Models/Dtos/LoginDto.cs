using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Qualisha.iCommunity.Data.Models.Dtos
{
    /// <summary>
    /// Login DTO model
    /// </summary>
    public class LoginDto
    {
        public LoginDto()
        {
            EmailAddress = string.Empty;
            Password = string.Empty;
        }

        [JsonProperty("email")]
        [Required(ErrorMessage = "Please provide email.")]
        [MinLength(3), MaxLength(255)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [JsonProperty("password")]
        [Required(ErrorMessage = "Please ender password.")]
        [MinLength(8), MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}