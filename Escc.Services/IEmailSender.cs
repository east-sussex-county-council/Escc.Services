﻿using System.Net.Mail;

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
    }
}
