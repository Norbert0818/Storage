using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace StorageSystem.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var apiKey = _configuration["SendGrid:ApiKey"];
            var fromEmail = new EmailAddress("ms9z7v@inf.elte.hu", "StorageSystem");
            var toEmailAddress = new EmailAddress(toEmail);
            var sendGridMessage = new SendGridMessage
            {
                From = fromEmail,
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            sendGridMessage.AddTo(toEmailAddress);

        }
    }
    //for testing
    //public class EmailService
    //{
    //    private readonly IConfiguration _configuration;
    //    private readonly ISendGridClient _sendGridClient;
    //    public EmailService(IConfiguration configuration, ISendGridClient sendGridClient)
    //    {
    //        _configuration = configuration;
    //        _sendGridClient = sendGridClient;
    //    }

    //    public async Task SendEmailAsync(string toEmail, string subject, string message)
    //    {
    //        var apiKey = _configuration["SendGrid:ApiKey"];
    //        var fromEmail = new EmailAddress("ms9z7v@inf.elte.hu", "StorageSystem");
    //        var toEmailAddress = new EmailAddress(toEmail);
    //        var sendGridMessage = new SendGridMessage
    //        {
    //            From = fromEmail,
    //            Subject = subject,
    //            PlainTextContent = message,
    //            HtmlContent = message
    //        };
    //        sendGridMessage.AddTo(toEmailAddress);

    //        await _sendGridClient.SendEmailAsync(sendGridMessage);
    //    }
    //}
}
