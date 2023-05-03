using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.Data.Models.Dtos
{
    public class ForgotPasswordDto
    {
        public ForgotPasswordDto()
        {
            EmailAddress = string.Empty;
        }
        public string EmailAddress { get; set; }
    }
}
