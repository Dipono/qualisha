using Microsoft.EntityFrameworkCore;
using Qualisha.iCommunity.Data.Models;
using Qualisha.iCommunity.RegistrationAPI.Model;

namespace Qualisha.iCommunity.Data
{
    public class ICommunityDbContext : DbContext
    {
        public ICommunityDbContext(DbContextOptions<ICommunityDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserOTP> UserOTPs { get; set; }

    }
}