using Gerenciamento_Usuario.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gerenciamento_Usuario.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IdentityUser> User { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<AccessUserType> AccessUserTypes { get; set; }
    }
}
