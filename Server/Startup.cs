using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using DentistryManagement.Server.Data;
using DentistryManagement.Server.Models;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Server.Services;
using System.IdentityModel.Tokens.Jwt;
using DentistryManagement.Server.Helpers;
using DentistryManagement.Server.DataTransferObjects;

namespace DentistryManagement.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<ApplicationRole>()  
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                  .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options => {
                      options.IdentityResources["openid"].UserClaims.Add("role");
                      options.ApiResources.Single().UserClaims.Add("role");
                  });

            JwtSecurityTokenHandler
                .DefaultInboundClaimTypeMap.Remove("role");

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.Configure<TeethSettingsDTO>(Configuration.GetSection("TeethSettings"));
    
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAffiliateService<AffiliateDTO>,AffiliateService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IDentistService, DentistService>();
            services.AddScoped<IPatientService<PatientDTO>, PatientService>();
            services.AddScoped<IMedicalChartService, MedicalChartService>();
            services.AddScoped<IDiseaseService<DiseaseDTO>, DiseaseService>();
            services.AddScoped<IToothService, ToothService>();
            services.AddScoped<IAllergyService, AllergyService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ITreatmentService<TreatmentDTO>, TreatmentService>();
            services.AddScoped<ITreatmentHistoryService, TreatmentHistoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserProviderService, UserProviderService>();
            services.AddScoped<IStatisticService, StatisticService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
                endpoints.MapFallbackToFile("/settings/{email?}", "index.html");
                endpoints.MapFallbackToFile("/affiliates/{id?}", "index.html");
                endpoints.MapFallbackToFile("/patients/{id?}", "index.html");
            });
        }
    }
}
