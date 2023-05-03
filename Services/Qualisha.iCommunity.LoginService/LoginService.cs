using Microsoft.EntityFrameworkCore;
using Qualisha.iCommunity.Data;
using Qualisha.iCommunity.RegistrationAPI.Model;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly ICommunityDbContext _dbContext;


        public LoginService(ICommunityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _dbContext.Users.SingleAsync(x => x.EmailAddress == username);

            if (user.Password == password)
            {
                return user;
            }

            return await Task.FromResult(new User());
        }
    }
}