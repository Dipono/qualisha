using Qualisha.iCommunity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.EmailService
{
    public interface IMailService
    {
        UserOTP GenerateOTP();
        bool SendEmail(string email, int userId);
    }
}
