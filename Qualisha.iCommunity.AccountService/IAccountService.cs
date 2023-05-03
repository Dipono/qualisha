using Qualisha.iCommunity.Data.Models.Dtos;
using Qualisha.iCommunity.RegistrationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.AccountService
{
    public interface IAccountService
    {
        bool ActivateAcoount(int userId);
        string VerifyOTP(int userId, string otp);
        string ForgotPassword(string email);
        bool UpdatePassword(int userId, string password);
        int UserDetails(string email);
    }
}
