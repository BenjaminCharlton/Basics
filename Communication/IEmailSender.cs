using MimeKit;
using System.Threading.Tasks;

namespace Basics.Communications
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task<(bool success, string errorMsg)> SendEmailAsync(
                string recepientName,
                string recepientEmail,
                string subject,
                string body,
                SmtpConfig config = null,
                bool isHtml = true);

        Task<(bool success, string errorMsg)> SendEmailAsync(
           string senderName,
           string senderEmail,
           string recepientName,
           string recepientEmail,
           string subject,
           string body,
           SmtpConfig config = null,
           bool isHtml = true);


        Task<(bool success, string errorMsg)> SendEmailAsync(
                   MailboxAddress sender,
                   MailboxAddress[] recepients,
                   string subject,
                   string body,
                   SmtpConfig config = null,
                   bool isHtml = true);

    }
}
