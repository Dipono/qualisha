using Qualisha.iCommunity.RegistrationAPI.Model;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.LoginService
{
    public interface ILoginService
    {
        Task<User> LoginAsync(string username, string password);
    }
}