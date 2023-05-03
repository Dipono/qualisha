using Autofac.Extras.Moq;
using Moq;
using Qualisha.iCommunity.Data;
using Qualisha.iCommunity.LoginService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests.Models
{
    public class LoginServiceTest
    {
        private readonly LoginService _loginService;
        private readonly ICommunityDbContext _dbContext;
        
        public LoginServiceTest(ICommunityDbContext dbContext)
        {
            _dbContext = dbContext;
            _loginService = new LoginService(_dbContext);
        }

        [Theory]
        [InlineData("manasoe@gmail.com", "12345",true)]
        public void LoginTestPass(string email, string password, bool expected)
        {
            
            var results = _loginService.Login(email,password);

            Assert.Equal(results,expected);
        }

        [Theory]
        [InlineData("manasoe@gmail.com", "12345")]
        [InlineData("","")]
        [InlineData(null,null)]
        [InlineData("", "Manasoe12@")]
        [InlineData("manasoe12gmail.com", "Manasoe12@")]
        [InlineData("manasoe12gmail", "Manasoe12@")]
        [InlineData("manasoe12gmail.com", "")]
        [InlineData("manasoe12gmail.com", "manasoe12@")]
        [InlineData("manasoe12gmail.com", "Manasoe@")]
        [InlineData("manasoe12gmail.com", "Manasoe12")]

        public void LoginTestFail(string email, string password)
        {
            Mock<ILoginService> _loginService = new Mock<ILoginService>();

            _loginService.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            var results = _loginService.Object;

            Assert.False(results.Login(email, password));
        }


    }
}
