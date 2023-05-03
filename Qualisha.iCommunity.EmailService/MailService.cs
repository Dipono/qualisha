using Qualisha.iCommunity.Data.Models;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using Qualisha.iCommunity.Data.Models.Dtos;
using Qualisha.iCommunity.Data;
using System.Linq;

namespace Qualisha.iCommunity.EmailService
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly ICommunityDbContext _dbContext;

        public MailService(IOptions<MailSettings> options, ICommunityDbContext dbContext)
        {
            _mailSettings = options.Value;
            _dbContext = dbContext;
        }
        public bool SendEmail(string email, int userId)
        {
            try
            {
                DateTime currentHour = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss tt").ToString());
                var getUserOTP = _dbContext.UserOTPs.Single(k => k.UserId == userId && k.ExpiryDate > currentHour && k.IsUsed == false);

                MailData mailData = new MailData();
                string FilePath = "../../../Qualisha.iCommunity/Qualisha.iCommunity.EmailService/SendMail.html";

                StreamReader readHtmlSendEmail = new StreamReader(FilePath);
                mailData.MailBody = readHtmlSendEmail.ReadToEnd();
                readHtmlSendEmail.Close();
                mailData.MailSubject = "One-Time-Pin";
                mailData.MailBody = mailData.MailBody.Replace("[generatedOTP]", getUserOTP.OTP.ToString().Trim());


                MailMessage mailMessage = new MailMessage(_mailSettings.EmailId, email);
                mailMessage.Subject = mailData.MailSubject;
                mailMessage.Body = mailData.MailBody;
                mailMessage.IsBodyHtml = true;

                var client = new SmtpClient(_mailSettings.Host, _mailSettings.Port)
                {
                    Credentials = new NetworkCredential(_mailSettings.UserName, _mailSettings.Password),
                    EnableSsl = true
                };
                client.Send(_mailSettings.EmailId, email, mailData.MailSubject, mailData.MailBody);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;

            }
        }

        public UserOTP GenerateOTP()
        {
            Random rand = new Random();
            int changeNumber;
            string getCode = "";
            int endNumber = 5;

            for (int countNumber = 0; countNumber < endNumber; countNumber++)
            {
                changeNumber = rand.Next(10);
                getCode += changeNumber.ToString();
            }

            DateTime currentHour = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss tt").ToString());
            DateTime expireDate = currentHour.AddHours(1);

            UserOTP userOTP = new UserOTP()
            {
                CreatedDate = currentHour,
                ExpiryDate = expireDate,
                IsUsed = false,
                OTP = getCode
            };

            return userOTP;
        }


    }
}
