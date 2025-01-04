using Common.Enum;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API_Hostel_Management.Extension
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection IdentityServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                    policy.RequireClaim("Role", ((int)AccountRoleEnum.Admin).ToString()));

                options.AddPolicy("Staff", policy =>
                    policy.RequireClaim("Role", ((int)AccountRoleEnum.Staff).ToString()));

                options.AddPolicy("Customer", policy =>
                    policy.RequireClaim("Role", ((int)AccountRoleEnum.Customer).ToString()));

                options.AddPolicy("CustomerAndAdmin", policy =>
                    policy.RequireClaim("Role", ((int)AccountRoleEnum.Admin).ToString(), ((int)AccountRoleEnum.Customer).ToString()));
            });
            return services;
        }
    }
}
