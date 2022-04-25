using LabGuru.BAL.Repo;
using LabGuru.DAL;
using LabGuru.DAL.DataContext;
using LabGuru.WebAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LabGuru.WebAPI
{

    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var key = "MyTokenVarificationKey";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );


            services.AddSingleton(new JwtAuthenticationManager(key));
            services.AddDbContext<LabGuruDbContext>(option => option.UseMySQL(configuration.GetConnectionString("Default")));
            services.AddScoped<IDoctor, DoctorDAL>();
            services.AddScoped<IAuthentication, AuthenticationDAL>();
            services.AddScoped<IProductTypeManage, ProductTypeDAL>();
            services.AddScoped<IProductMaterial, ProductMaterialDAL>();
            services.AddScoped<IProductShade, ProductShadeDAL>();
            services.AddScoped<IToothnoMasters, ToothnoMastersDAL>();
            services.AddScoped<IOrderManage, OrderManageDAL>();
            services.AddScoped<IDoctorClinic, DoctorClinicDAL>();
            services.AddScoped<ILaboratory, LaboratoryDAL>();
            services.AddScoped<IOrderProcessMaster, OrderProcessMasterDAL>();
            services.AddScoped<IProductSetting, ProductSettingDAL>();
            services.AddScoped<IOrderStatus, OrderStatusDAL>();
            services.AddScoped<IDoctorLabMapping, DoctorLabMappingDAL>();
            services.AddScoped<IOrderStatusMaster, OrderStatusMasterDAL>();
            services.AddSingleton<ResponceMessages, ResponceMessages>();
            services.AddScoped<IDoctorStatusSetting, DoctorStatusSettingDAL>();
            services.AddScoped<ILabAssignment, LabAssignmentDAL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();

            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
