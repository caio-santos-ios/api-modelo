using api_infor_cell.src.Configuration;
using api_infor_cell.src.Models;
using MongoDB.Driver;

namespace api_infor_cell.src.Shared.Templates
{
    public class MailTemplate(AppDbContext context)
    {
        private static readonly string UiUri              = Environment.GetEnvironmentVariable("UI_URI")                   ?? "";
        private static readonly string BrandName          = Environment.GetEnvironmentVariable("BRAND_NAME")               ?? "";
        private static readonly string BrandColorPrimary  = Environment.GetEnvironmentVariable("BRAND_COLOR_PRIMARY")      ?? "#7127A7";
        private static readonly string BrandColorPrimaryRgb = Environment.GetEnvironmentVariable("BRAND_COLOR_PRIMARY_RGB") ?? "113,39,167";
        private static readonly string BrandColorMid      = Environment.GetEnvironmentVariable("BRAND_COLOR_MID")          ?? "#A862DC";
        private static readonly string BrandColorAccent   = Environment.GetEnvironmentVariable("BRAND_COLOR_ACCENT")       ?? "#C492F0";

        private static string ApplyBrandVars(string html) {
            return html
                .Replace("{{brand_name}}",            BrandName)
                .Replace("{{brand_color_primary}}",   BrandColorPrimary)
                .Replace("{{brand_color_primary_rgb}}", BrandColorPrimaryRgb)
                .Replace("{{brand_color_mid}}",       BrandColorMid)
                .Replace("{{brand_color_accent}}",    BrandColorAccent)
                .Replace("{{ui_uri}}",                UiUri);
        }

        public async Task<string> ForgotPasswordWeb(string name, string code)
        {
            Template? template = await context.Templates
                .Find(x => x.Code == "FORGOT_PASSWORD_WEB" && !x.Deleted)
                .FirstOrDefaultAsync();

            if (template is null) return "";

            return ApplyBrandVars(template.Html)
                .Replace("{{name}}", name)
                .Replace("{{code}}", code);
        }

        public async Task<string> FirstAccess(string name, string email, string password)
        {
            Template? template = await context.Templates
                .Find(x => x.Code == "FIRST_ACCESS" && !x.Deleted)
                .FirstOrDefaultAsync();

            if (template is null) return "";

            return ApplyBrandVars(template.Html)
                .Replace("{{name}}",     name)
                .Replace("{{email}}",    email)
                .Replace("{{password}}", password);
        }
        public async Task<string> ConfirmAccount(string name, string code)
        {
            Template? template = await context.Templates
                .Find(x => x.Code == "CONFIRM_ACCOUNT" && !x.Deleted)
                .FirstOrDefaultAsync();

            if (template is null) return code;

            return ApplyBrandVars(template.Html)
                .Replace("{{name}}", name)
                .Replace("{{code}}", code);
        }

        public async Task<string> NewCodeConfirmAccount(string name, string code)
        {
            Template? template = await context.Templates
                .Find(x => x.Code == "NEW_CODE_CONFIRM_ACCOUNT" && !x.Deleted)
                .FirstOrDefaultAsync();

            if (template is null) return code;

            return ApplyBrandVars(template.Html)
                .Replace("{{name}}", name)
                .Replace("{{code}}", code);
        }

        public async Task<string> NewLinkCodeConfirmAccount(string name, string code)
        {
            Template? template = await context.Templates
                .Find(x => x.Code == "NEW_LINK_CODE_CONFIRM_ACCOUNT" && !x.Deleted)
                .FirstOrDefaultAsync();

            if (template is null) return code;

            return ApplyBrandVars(template.Html)
                .Replace("{{name}}", name)
                .Replace("{{code}}", $"{UiUri}/confirm-account/{code}");
        }
    }
}