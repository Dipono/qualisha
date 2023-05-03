using Microsoft.EntityFrameworkCore;
using Qualisha.iCommunity.Data;
using Qualisha.iCommunity.Data.Models;
using Qualisha.iCommunity.RegistrationAPI.Model;
using Qualisha.iCommunity.RegistrationService;
using System.Threading.Tasks;
using Xunit;

namespace Qualisha.iCommunity.Services.Tests.RegisterServiceTests
{
    public class RegisterServiceTests
    {/*
        private readonly DbContextOptions<ICommunityDbContext> _dbContextOptions;

        public RegisterServiceTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ICommunityDbContext>().UseInMemoryDatabase("ICommunityDb").Options;
        }

        [Theory]
        [InlineData("qualisha@home.com", false)]
        [InlineData("lorem.Ipsum@test.com", true)]
        public async Task When_Calling_CheckEmailExist(string email, bool expected)
        {
            var regService = await CreateRegistrationServiceAsync();

            var actual = regService.CheckExistingEmail(email);

            Assert.True(actual == expected);
        }

        [Theory]
        [InlineData("Abc.example.com", false)]
        [InlineData("A@b@c@example.com", false)]
        [InlineData("ma_@jjf", false)]
        [InlineData("lorem.ipsum@test.com", true)]
        [InlineData("ma@hostname.com", true)]
        [InlineData("ma-a@hostname.com.edu", true)]
        public async Task When_Calling_ValidadeEmail(string email, bool expected)
        {
            var regService = await CreateRegistrationServiceAsync();

            var actual = regService.ValidateEmail(email);

            Assert.True(actual == expected);
        }

        [Fact]
        public async Task When_Calling_RegisterAsync()
        {
            var regService = await CreateRegistrationServiceAsync();

            var address = new Address
            {
                City = "PTA",
                Province = "Gauteng",
                Estate = "Super Stone",
                Suburb = "Mowani",
                Code = "0144"
            };

            var user = new User
            {
                FirstName = "Lorem",
                LastName = "Ipsum",
                EmailAddress = "lorem.Ipsum@test.com",
                Password = "@Password123",
                Address = address
            };
            var result = await regService.RegisterAsync(user, address);

            Assert.NotNull(result);
            Assert.Equal(result.EmailAddress, user.EmailAddress);
        }

        private async Task<RegisterService> CreateRegistrationServiceAsync(string email = "")
        {
            var dbContext = new ICommunityDbContext(_dbContextOptions);

            await SetupDbContext(dbContext, email);

            return new RegisterService(dbContext);
        }

        private static async Task SetupDbContext(ICommunityDbContext context, string email = "")
        {
            var address = new Address
            {
                City = "PTA",
                Province = "Gauteng",
                Estate = "Super Stone",
                Suburb = "Mowani",
                Code = "0144"
            };

            await context.Addresses.AddAsync(address);

            var user = new User
            {
                FirstName = "Lorem",
                LastName = "Ipsum",
                EmailAddress = "lorem.Ipsum@test.com",
                Password = "@Password123",
                Address = address
            };

            if (!string.IsNullOrWhiteSpace(email))
            {
                user.EmailAddress = email;
            }

            await context.Users.AddAsync(user);

            await context.SaveChangesAsync();
        }*/
    }
}