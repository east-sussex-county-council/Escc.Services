using System;
using System.Net.Mail;

namespace Escc.Services
{
    /// <summary>
    /// Sends an email using settings configured for System.Net.Mail
    /// </summary>
    public class SmtpEmailSender : IEmailSender       
    {
        public void Send(MailMessage message)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Send(message);
            }
        }
    }
}