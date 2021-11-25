
using Hiking.Data;
using Hiking.Data.DataLayers;
using Hiking.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hiking
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
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();
            
           string connectionStringlocal = Configuration.GetConnectionString("HikingContextProd"); // qui se trouve dans l'appsettings.json
           
           

            services.AddTransient<HikeDataLayer, HikeDataLayer>(); // on injecte une dépendance et on s'assure que c'est la bonne instance qui est renvoyée
            services.AddTransient<IEmailSender, EmailSender>();


            //Azure db check
            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                services.AddDbContext<HikingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HikingContextProd")), ServiceLifetime.Scoped);
            else
                services.AddDbContext<HikingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HikingContext")), ServiceLifetime.Scoped);

            //Perform databse migration automatically
            //services.BuildServiceProvider().GetService<HikingContext>().Database.Migrate();

            services.AddDefaultIdentity<IdentityUser>(options => {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
            }).AddRoles<IdentityRole>()
                 .AddEntityFrameworkStores<HikingContext>().AddDefaultTokenProviders();

            //services.Configure<IdentityOptions>(options =>
            //{

            //    options.User.RequireUniqueEmail = true;

            //});

            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Role");
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Manage/Index", "/MyProfile");
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "/Login");
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,HikingContext hikingcontext)
        {


            //Perform databse migration automatically
            hikingcontext.Database.Migrate();

            ApplicationDbInitializer.SeedUsers(userManager,roleManager,Configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

           

            //Allows to enter input decimal values
            app.Use(async (context, next) =>
            {
                var currentThreadCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
                currentThreadCulture.NumberFormat = NumberFormatInfo.InvariantInfo;

                Thread.CurrentThread.CurrentCulture = currentThreadCulture;
                Thread.CurrentThread.CurrentUICulture = currentThreadCulture;

                await next();
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
                endpoints.MapRazorPages();
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    
                 );

             
                endpoints.MapControllerRoute(
             name: "edithike",
             pattern: "edit-hike/{id}",
             defaults: new { controller = "Hike", action = "Edit" },
             constraints: new { id = @"\d+" } // on checke si c'est un entier
                                              //constraints: new { id = new LogConstraint() }
                                              //constraints: new { id = new LogConstraint() }
             );

                


            });


        }

      
    }
}
