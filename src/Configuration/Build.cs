using api_infor_cell.src.Handlers;
using api_infor_cell.src.Interfaces;
using api_infor_cell.src.Repository;
using api_infor_cell.src.Services;
using api_infor_cell.src.Shared.Templates;
using CloudinaryDotNet;

namespace api_infor_cell.src.Configuration
{
    public static class Build
    {
        public static void AddBuilderConfiguration(this WebApplicationBuilder builder)
        {
            AppDbContext.ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "";
            AppDbContext.DatabaseName     = Environment.GetEnvironmentVariable("DATABASE_NAME")     ?? "";
            AppDbContext.IsSSL = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("IS_SSL")) && Convert.ToBoolean(Environment.GetEnvironmentVariable("IS_SSL"));
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

            builder.Services.AddTransient<ITriggerService, TriggerService>();
            builder.Services.AddTransient<ITriggerRepository, TriggerRepository>();

            // REALTIME
            builder.Services.AddTransient<INotificationService, NotificationService>();
            builder.Services.AddTransient<INotificationRepository, NotificationRepository>();

            builder.Services.AddTransient<IChatService, ChatService>();
            builder.Services.AddTransient<IChatRepository, ChatRepository>();

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

            // Cloudinary
            Account account = new(
                Environment.GetEnvironmentVariable("CLOUDINARY_CLOUD_NAME"),
                Environment.GetEnvironmentVariable("CLOUDINARY_API_KEY"),
                Environment.GetEnvironmentVariable("CLOUDINARY_API_SECRET")
            );
            builder.Services.AddSingleton(new Cloudinary(account));

            // SignalR — já incluído no ASP.NET Core, sem NuGet extra
            builder.Services.AddSignalR();
        }
    }
}