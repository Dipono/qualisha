using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.Data.Models.Dtos
{
    public class ActiveAccountDto
    {
        public int UserId { get; set; }
        public string OTP { get; set; }

        public ActiveAccountDto()
        {
            OTP = string.Empty;
        }
    }
}
