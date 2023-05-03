<<<<<<< HEAD
﻿using Qualisha.iCommunity.Data;
using System;
=======
﻿using System;
>>>>>>> 406c525a6c2dddb071ffe8e0b69dfc1ae6d3f35f
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.ActivateAccountService
{
<<<<<<< HEAD
    public class ActivateAccountService : IActivateAccountService
    {
        private readonly ICommunityDbContext _dbContext;

        public ActivateAccountService(ICommunityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string ActivateAccount(string email, int otp)
        {
            var user = _dbContext.Users.Single(userActive => userActive.EmailAddress == email);
            var userOtp = _dbContext.UserOTPs.Single(userotp => userotp.UserId == user.Id && userotp.OTP == otp);

            DateTime currentHour = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss tt").ToString());

            if (user == null)
            {
                return "Wrong Email address";
            }

            if (userOtp == null)
            {
                return "Does not match OTP";
            }

            if (userOtp.ExpiryDate < currentHour)
            {
                return "OTP has expired";
            }

            user.Active = true;

            return "Activated Successfully";
        }

        public string ForgotPassword()
        {
            return "";
=======
    internal class ActivateAccountService
    {
        public bool ActivateAccount(int user, string otp)
        {
            return true;
>>>>>>> 406c525a6c2dddb071ffe8e0b69dfc1ae6d3f35f
        }
    }
}
