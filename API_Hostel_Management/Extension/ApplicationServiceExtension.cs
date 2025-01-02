using Repository.Implement;
using Repository.Interface;
using Service.Implement;
using Service.Interface;
using Service.Mail;

namespace API_Hostel_Management.Extension
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services
       , IConfiguration config)
        {
            //Repository
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IMeasurementRepository, MeasurementRepository>();

            //Service
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IMeasurementService, MeasurementService>();


            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<MailSetting>(config.GetSection("MailSetting"));

            return services;
        }
        }
}
