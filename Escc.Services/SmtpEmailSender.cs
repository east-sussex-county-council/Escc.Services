using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Escc.Services
{
    /// <summary>
    /// Sends an email using settings configured for System.Net.Mail
    /// </summary>
    public class SmtpEmailSender : IEmailSender
    {
        /// <summary>
        /// Sends the specified email.
        /// </summary>
        /// <param name="message">The email.</param>
        public void Send(MailMessage message)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Send(message);
            }
        }

        /// <summary>
        /// Sends the specified email asynchronously.
        /// </summary>
        /// <param name="message">The email.</param>
        public async Task SendAsync(MailMessage message)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.SendCompleted += (sender, args) => message.Dispose();
                await smtp.SendMailAsync(message);
            }
        }
    }
}