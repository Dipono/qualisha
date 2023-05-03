using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.ActivateAccountService
{
<<<<<<< HEAD
    namespace Qualisha.iCommunity.ActivateAccountService
    {
        public interface IActivateAccountService
        {
            string ActivateAccount(string email, int otp);
            string ForgotPassword();
        }
    }

=======
    public interface IActivateAccountService
    {
        bool ActivateAccount(int user, string otp);
    }
>>>>>>> 406c525a6c2dddb071ffe8e0b69dfc1ae6d3f35f
}
