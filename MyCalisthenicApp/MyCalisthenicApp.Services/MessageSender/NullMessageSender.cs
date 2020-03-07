namespace MyCalisthenicApp.Services.MessageSender
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class NullMessageSender
    {
        public Task SendEmailAsync(
          string from,
          string fromName,
          string to,
          string subject,
          string htmlContent,
          IEnumerable<EmailAttachment> attachments = null)
        {
            return Task.CompletedTask;
        }
    }
}
