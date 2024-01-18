using Medical.Application.Contracts.Infrastructure;
using Medical.Domain.Entities;
using System.Net;
using System.Net.Mail;
namespace Medical.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmailAsync(Email EmailSend)
        {
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("45ccf510fce37d", "66de414283b0ec"),
                EnableSsl = true
            };

            await client.SendMailAsync(EmailSend.From!, EmailSend.To!, EmailSend.Subject, EmailSend.Message);

            return true;
        }
    }
}
