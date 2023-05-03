using Qualisha.iCommunity.Data;
using Qualisha.iCommunity.Data.Models;
using Qualisha.iCommunity.EmailService;
using Qualisha.iCommunity.RegistrationAPI.Model;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.RegistrationService
{
    /// <summary>
    /// User Registration service
    /// </summary>
    public class RegisterService : IRegisterService
    {
        private readonly ICommunityDbContext _dbContext;
        private readonly IMailService _mailService;

        public RegisterService(ICommunityDbContext dbContext, IMailService mailService)
        {
            _dbContext = dbContext;
            _mailService = mailService;
        }

        /// <summary>
        /// Saves user details to the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task<User> RegisterAsync(User user, Address address)
        {
            await _dbContext.Addresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();

            user.AddressId = address.Id;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            UserOTP userOTP = new UserOTP();
            userOTP = _mailService.GenerateOTP();
            userOTP.UserId = user.Id;

            _dbContext.UserOTPs.Add(userOTP);
            await _dbContext.SaveChangesAsync();
                       

            return user;
           
        }

        /// <summary>
        /// Check if Email is Already in the Database
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool CheckExistingEmail(string email)
        {
            return _dbContext.Users.Any(x => x.EmailAddress == email);
        }

        /// <summary>
        /// Validate the Email, Whether is in Correct Format or Not
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                static string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

    }
}