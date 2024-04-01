/*using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetAdoptionCenter.Core.Services
{
    public class EmailNotificationService: INotificationService
    {
        private readonly IConfiguration _configuration;

        public EmailNotificationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendNotificationAsync(string userId, string message)
        {
            // Retrieve user email from userId
            var userEmail = GetUserEmail(userId);

            // Configure SMTP settings from appsettings.json or configuration source
            string smtpServer = _configuration["EmailSettings:SmtpServer"];
            int smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
            string smtpUsername = _configuration["EmailSettings:SmtpUsername"];
            string smtpPassword = _configuration["EmailSettings:SmtpPassword"];

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                // Construct the email message
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpUsername),
                    Subject = "Notification from Virtual Pet Adoption Center",
                    Body = message,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(new MailAddress(userEmail));
                // Send the email
                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
*/