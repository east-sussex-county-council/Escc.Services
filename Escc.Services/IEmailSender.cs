using System.Net.Mail;
using System.Threading.Tasks;

namespace Escc.Services
{
    /// <summary>
    /// A method of sending emails
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends the specified email.
        /// </summary>
        /// <param name="message">The email.</param>
        void Send(MailMessage message);

        /// <summary>
        /// Sends the specified email asynchronously.
        /// </summary>
        /// <param name="message">The email.</param>
        Task SendAsync(MailMessage message);
    }
}
