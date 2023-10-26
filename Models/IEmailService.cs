using System.Net.Mail;
using System.Net;

namespace GeeksProject02.Models
{
    public interface IEmailService
    {
        Task SendAppointmentStatusEmailAsync(string toEmail, string subject, string message);
    }

    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _fromEmail;

        public EmailService(IConfiguration configuration)
        {
            _fromEmail = configuration["EmailSettings:FromEmail"];

            _smtpClient = new SmtpClient(); // Initialize _smtpClient here

            string smtpServer = configuration["EmailSettings:SmtpServer"];
            if (smtpServer != null)
            {
                _smtpClient.Host = smtpServer;
            }
            else
            {
                // Handle the case where the SMTP server is missing or null.
                // You can log an error, throw an exception, or take appropriate action.
            }

            _smtpClient.Port = int.Parse(configuration["EmailSettings:SmtpPort"] ?? "587");
            _smtpClient.EnableSsl = true;
            _smtpClient.Credentials = new NetworkCredential(
                configuration["EmailSettings:SmtpUsername"],
                configuration["EmailSettings:SmtpPassword"]
            );
        }




        public async Task SendAppointmentStatusEmailAsync(string toEmail, string subject, string message)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_fromEmail),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            await _smtpClient.SendMailAsync(mailMessage);
        }
    }

}