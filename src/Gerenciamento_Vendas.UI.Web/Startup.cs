using Application.Interfaces.Persons.UserManager;
using Application.OpenApps.Persons.ManagerUsers;
using Domain.Interfaces.Generics;
using Domain.Interfaces.Persons.UserManager;
using Entity.Persons.Identity.Users;
using Infrastructure.Configurations.Contexts;
using Infrastructure.Repositories.Generics;
using Infrastructure.Repositories.Persons.UserManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gerenciamento_Vendas.UI.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BaseDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<BaseDbContext>();
            services.AddControllersWithViews();


            //INTERFACES E REPOSITÓRIOS
            services.AddSingleton(typeof(IGeneric<>), typeof(GenericRepository<>));
            services.AddSingleton<IUserType, UserTypeRepository>();
            services.AddSingleton<IUserProfile, UserProfileRepository>();
            services.AddSingleton<IAccessUserType, AccessUserTypeRepository>();

            // INTERFACE APLICAÇÃO
            services.AddSingleton<IUserTypeApp, UserTypeApp>();

            // SERVIÇO DOMINIO
            //services.AddSingleton<IService, ServiceCd>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
