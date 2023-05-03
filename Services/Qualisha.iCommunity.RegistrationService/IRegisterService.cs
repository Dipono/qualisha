using Qualisha.iCommunity.Data.Models;
using Qualisha.iCommunity.RegistrationAPI.Model;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.RegistrationService
{
    public interface IRegisterService
    {
        Task<User> RegisterAsync(User user, Address address);

        bool ValidateEmail(string email);

        bool CheckExistingEmail(string email);

    }
}