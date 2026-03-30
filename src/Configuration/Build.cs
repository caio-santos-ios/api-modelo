using System.Text;
using api_infor_cell.src.Handlers;
using api_infor_cell.src.Interfaces;
using api_infor_cell.src.Repository;
using api_infor_cell.src.Services;
using api_infor_cell.src.Shared.Templates;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace api_infor_cell.src.Configuration
{
    public static class Build
    {
        public static void AddBuilderConfiguration(this WebApplicationBuilder builder)
        {
            AppDbContext.ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? ""; 
            AppDbContext.DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME") ?? ""; 
            bool IsSSL;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("IS_SSL")))
            {
                IsSSL = Convert.ToBoolean(Environment.GetEnvironmentVariable("IS_SSL"));
            }
            else
            {
                IsSSL = false;
            }

            AppDbContext.IsSSL = IsSSL;
        }
        public static void AddBuilderAuthentication(this WebApplicationBuilder builder)
        {
            string? SecretKey = Environment.GetEnvironmentVariable("SECRET_KEY") ?? "";
            string? Issuer = Environment.GetEnvironmentVariable("ISSUER") ?? "";
            string? Audience = Environment.GetEnvironmentVariable("AUDIENCE") ?? "";
            
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Issuer,
                    ValidAudience = Audience,
                    ClockSkew = TimeSpan.FromMinutes(5),
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(SecretKey)
                    )
                };
            });
        }
        public static void AddContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<AppDbContext>();
        }
        public static void AddBuilderServices(this WebApplicationBuilder builder)
        {
            // AUTH
            builder.Services.AddTransient<IAuthService, AuthService>();                  
            
            // MASTER DATA
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();  

            builder.Services.AddTransient<IProfileUserService, ProfileUserService>();
            builder.Services.AddTransient<IProfileUserRepository, ProfileUserRepository>();  

            // SETTINGS
            builder.Services.AddTransient<ILoggerService, LoggerService>();
            builder.Services.AddTransient<ILoggerRepository, LoggerRepository>();
            
            builder.Services.AddTransient<ITemplateService, TemplateService>();
            builder.Services.AddTransient<ITemplateRepository, TemplateRepository>();
            
            // DASHBOARD
            // builder.Services.AddTransient<IDashboardService, DashboardService>();
            // builder.Services.AddTransient<IDashboardRepository, DashboardRepository>();

            // Handlers
            builder.Services.AddTransient<SmsHandler>();
            builder.Services.AddTransient<MailHandler>();
            builder.Services.AddTransient<UploadHandler>();
            builder.Services.AddTransient<CountHandler>();

            // Templates
            builder.Services.AddTransient<MailTemplate>();

            // AutoMapper
            builder.Services.AddAutoMapper(cfg => { }, typeof(Program));

            // CLOUDINARY
            Account account = new(
                Environment.GetEnvironmentVariable("CLOUDINARY_CLOUD_NAME"),
                Environment.GetEnvironmentVariable("CLOUDINARY_API_KEY"),
                Environment.GetEnvironmentVariable("CLOUDINARY_API_SECRET")
            );
            builder.Services.AddSingleton(new Cloudinary(account));
        }
    }
}