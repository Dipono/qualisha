using Qualisha.iCommunity.Data;
using Qualisha.iCommunity.Data.Models;
using Qualisha.iCommunity.Data.Models.Dtos;
using Qualisha.iCommunity.EmailService;
using Qualisha.iCommunity.RegistrationAPI.Model;
using Qualisha.iCommunity.RegistrationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly ICommunityDbContext _dbContext;
        private readonly IRegisterService _register;
        private readonly IMailService _mail;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="register"></param>
        /// <param name="mail"></param>
        public AccountService(ICommunityDbContext dbContext, IRegisterService register, IMailService mail)
        {
            _dbContext = dbContext;
            _register = register;
            _mail = mail;
        }

        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool ActivateAcoount(int userId)
        {
            var user = _dbContext.Users.Single(userOtp => userOtp.Id == userId);
            user.Active = true;

            _dbContext.SaveChanges();
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="otp"></param>
        /// <returns></returns>
        public string VerifyOTP(int userId, string otp)
        {
            var userOtp = _dbContext.UserOTPs.SingleOrDefault(userotp => userotp.UserId == userId && userotp.OTP == otp);
            DateTime currentHour = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss tt").ToString());
            if (userOtp == null)
            {
                return "Does not match OTP";
            }

            if (userOtp.ExpiryDate < currentHour)
            {
                return "OTP has expired";
            }

            if (userOtp.IsUsed == true)
            {
                return "OTP has been Used";
            }
            userOtp.IsUsed = true;
            _dbContext.SaveChanges();
            return "success";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string ForgotPassword(string email)
        {
            var userExist = _dbContext.Users.SingleOrDefault(chechEmail => chechEmail.EmailAddress == email);

            if (userExist == null)
            {
                return "Cannot find this email";
            }
            DateTime currentTime = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss tt").ToString());
            var ExistUserOTP = _dbContext.UserOTPs.SingleOrDefault(k => k.UserId == userExist.Id && k.IsUsed == false);

            if (ExistUserOTP != null)
            {
                ExistUserOTP.IsUsed = true;
                _dbContext.SaveChanges();
            }

            UserOTP userOTP = new UserOTP();
            userOTP = _mail.GenerateOTP();
            userOTP.UserId = userExist.Id;

            _dbContext.UserOTPs.Add(userOTP);
            _dbContext.SaveChanges();
            var sendMail = _mail.SendEmail(userExist.EmailAddress, userExist.Id);

            if (!sendMail)
            {
                return "Something went wrong";
            }

            return "OTP send on your email";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int UserDetails(string email)
        {
            var user = _dbContext.Users.SingleOrDefault(userInfo => userInfo.EmailAddress == email);
            if (user == null)
            {
                return 0;
            }
            return user.Id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool UpdatePassword(int userId, string password)
        {
            var userDetails = _dbContext.Users.SingleOrDefault(userById => userById.Id == userId);
            if (userDetails == null) { return false; }

            userDetails.Password = password;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
