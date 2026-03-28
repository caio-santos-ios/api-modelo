using api_infor_cell.src.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace api_infor_cell.src.Handlers
{
    public class MailHandler(ILoggerService loggerService)
    {
        private readonly string EmailFrom = Environment.GetEnvironmentVariable("EMAIL_FROM") ?? "";
        private readonly string Password = Environment.GetEnvironmentVariable("PASSWORD_EMAIL") ?? "";
        private readonly string ResendApiKey = Environment.GetEnvironmentVariable("RESEND_API_KEY") ?? "";

        public async Task SendMailAsync(string recipient, string subject, string body)
        {
            try
            {
                MimeMessage mensagem = new();
                mensagem.From.Add(MailboxAddress.Parse(EmailFrom));
                mensagem.To.Add(MailboxAddress.Parse(recipient));
                mensagem.Subject = subject;
                mensagem.Body = new TextPart("html") { Text = body };

                using SmtpClient smtp = new();
                
                // SMTP do Resend — Railway não bloqueia (é HTTPS por baixo)
                await smtp.ConnectAsync("smtp.resend.com", 465, SecureSocketOptions.SslOnConnect);
                await smtp.AuthenticateAsync("resend", ResendApiKey); // usuário é literal "resend"
                await smtp.SendAsync(mensagem);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                await loggerService.CreateAsync(new () 
                {
                    Method = "SendMailAsync",
                    Message = $"Failed to send email: {ex.Message}",
                    StatusCode = 500
                });
                throw;
            }
        } 
    }
}