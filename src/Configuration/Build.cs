using api_infor_cell.src.Filters;
using api_infor_cell.src.Handlers;
using api_infor_cell.src.Interfaces;
using api_infor_cell.src.Repository;
using api_infor_cell.src.Services;
using api_infor_cell.src.Shared.Templates;
using api_infor_cell.src.Workers;
using CloudinaryDotNet;

namespace api_infor_cell.src.Configuration
{
    public static class Build
    {
        public static void AddBuilderConfiguration(this WebApplicationBuilder builder)
        {
            AppDbContext.ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "";
            AppDbContext.DatabaseName     = Environment.GetEnvironmentVariable("DATABASE_NAME")     ?? "";
            AppDbContext.IsSSL = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("IS_SSL"))
                && Convert.ToBoolean(Environment.GetEnvironmentVariable("IS_SSL"));
        }

        public static void AddContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<AppDbContext>();
        }

        public static void AddBuilderServices(this WebApplicationBuilder builder)
        {
            // AUTH
            builder.Services.AddTransient<IAuthService, AuthService>();

            // DASHBOARD
            builder.Services.AddTransient<IDashboardService, DashboardService>();
            builder.Services.AddTransient<IDashboardRepository, DashboardRepository>();

            // MASTER DATA
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IProfileUserService, ProfileUserService>();
            builder.Services.AddTransient<IProfileUserRepository, ProfileUserRepository>();
            builder.Services.AddTransient<ICustomerService, CustomerService>();
            builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
            builder.Services.AddTransient<ISupplierService, SupplierService>();
            builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();

            // FINANCIAL
            builder.Services.AddTransient<IAccountReceivableService, AccountReceivableService>();
            builder.Services.AddTransient<IAccountReceivableRepository, AccountReceivableRepository>();
            builder.Services.AddTransient<IAccountPayableService, AccountPayableService>();
            builder.Services.AddTransient<IAccountPayableRepository, AccountPayableRepository>();
            builder.Services.AddTransient<IChartOfAccountsRepository, ChartOfAccountsRepository>();
            builder.Services.AddTransient<IChartOfAccountsService, ChartOfAccountsService>();
            builder.Services.AddTransient<IDreRepository, DreRepository>();
            builder.Services.AddTransient<IDreService, DreService>();
            builder.Services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
            builder.Services.AddTransient<IPaymentMethodService, PaymentMethodService>();

            // OS
            builder.Services.AddTransient<IServiceOrderService, ServiceOrderService>();
            builder.Services.AddTransient<IServiceOrderRepository, ServiceOrderRepository>();
            builder.Services.AddTransient<IServiceOrderItemService, ServiceOrderItemService>();
            builder.Services.AddTransient<IServiceOrderItemRepository, ServiceOrderItemRepository>();
            builder.Services.AddTransient<ISituationService, SituationService>();
            builder.Services.AddTransient<ISituationRepository, SituationRepository>();

            // SETTINGS
            builder.Services.AddScoped<ILoggerService, LoggerService>();
            builder.Services.AddScoped<ILoggerRepository, LoggerRepository>();
            builder.Services.AddTransient<ITemplateService, TemplateService>();
            builder.Services.AddTransient<ITemplateRepository, TemplateRepository>();
            builder.Services.AddTransient<ITriggerService, TriggerService>();
            builder.Services.AddTransient<ITriggerRepository, TriggerRepository>();
            builder.Services.AddTransient<IAttachmentService, AttachmentService>();
            builder.Services.AddTransient<IAttachmentRepository, AttachmentRepository>();
            builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();

            // REALTIME
            builder.Services.AddTransient<INotificationService, NotificationService>();
            builder.Services.AddTransient<INotificationRepository, NotificationRepository>();
            builder.Services.AddTransient<IChatService, ChatService>();
            builder.Services.AddTransient<IChatRepository, ChatRepository>();

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

            // SignalR
            builder.Services.AddSignalR();

            // LoggerActionFilter — grava log automaticamente no final de cada requisição
            builder.Services.AddScoped<LoggerActionFilter>();
            
            // Work
            builder.Services.AddHostedService<FinancialWork>();
        }
    }
}