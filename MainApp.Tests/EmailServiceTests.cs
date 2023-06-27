using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SendGrid;
using SendGrid.Helpers.Mail;
using StorageSystem.Services;
using System.Threading.Tasks;

namespace MainApp.Tests
{
    [TestClass]
    public class EmailServiceTests
    {
        [TestMethod]
        public async Task SendEmailAsync_SendsEmailWithCorrectParameters()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var sendGridClientMock = new Mock<ISendGridClient>();
            //var emailService = new EmailService(configurationMock.Object, sendGridClientMock.Object); // Inject the sendGridClientMock
            var toEmail = "test@example.com";
            var subject = "Test Subject";
            var message = "Test Message";

            // Configure IConfiguration mock to return a dummy API key
            configurationMock.Setup(c => c["SendGrid:ApiKey"]).Returns("dummyApiKey");

            // Act
            //await emailService.SendEmailAsync(toEmail, subject, message);

            // Assert
            sendGridClientMock.Verify(
                c => c.SendEmailAsync(
                    It.Is<SendGridMessage>(msg =>
                        msg.From.Email == "ms9z7v@inf.elte.hu" &&
                        msg.From.Name == "StorageSystem" &&
                        msg.Personalizations[0].Tos[0].Email == toEmail &&
                        msg.Subject == subject &&
                        msg.PlainTextContent == message &&
                        msg.HtmlContent == message
                    ),
                    default
                ),
                Times.Once
            );
        }
    }
}
