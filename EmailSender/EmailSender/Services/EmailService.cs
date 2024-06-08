using EmailSender.Models;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace EmailSender.Services
{
    public interface IEmailService
    {
        void SendEmail(Email email);   
    }
    public class EmailService : IEmailService
    {
        private readonly IConfiguration config;

        public EmailService(IConfiguration config)
        {
            this.config = config;
        }

        public void SendEmail(Email email)
        {
            var mm = new MimeMessage();
            mm.From.Add(MailboxAddress.Parse(config.GetSection("EUserName").Value));
            mm.To.Add(MailboxAddress.Parse(email.ToMail));
            mm.Subject = email.Subject;
            mm.Body = new TextPart(TextFormat.Html) { Text = email.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(config.GetSection("EHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(email.ToMail, email.Password);
            smtp.Send(mm);
            smtp.Disconnect(true);
        }
    }
}
