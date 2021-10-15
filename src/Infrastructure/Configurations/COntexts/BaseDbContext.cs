using Entity.Persons.Identity.Users;
using Entity.Persons.Identity.Users.UsersManager;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations.Contexts
{
    public class BaseDbContext : IdentityDbContext<ApplicationUser>
    {

        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) { }

        //Configuação da tabela de usuário do IDentity
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        //configuração das tabelas de gerenciamento de usuários
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserProfile> userProfiles { get; set; }
        public DbSet<AccessTypeUser> AccessTypeUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }


        private string GetStringConectionConfig()
        {
            string strCon = "Data Source=DESKTOP-PAULO\\SQLEXPRESS;Initial Catalog=Smart_Cd.db_2021;Integrated Security=False;User ID=sa;Password=toor;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            return strCon;
        }

    }
}
