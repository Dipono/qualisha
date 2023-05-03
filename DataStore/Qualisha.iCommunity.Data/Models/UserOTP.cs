using Qualisha.iCommunity.RegistrationAPI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.Data.Models
{
    public class UserOTP
    {
     public UserOTP()
        {
            OTP = string.Empty;
        }
        public int Id { get; set; }
        public string OTP { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsUsed { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
