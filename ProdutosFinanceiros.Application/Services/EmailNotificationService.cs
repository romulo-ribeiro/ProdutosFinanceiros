using System.Text;
using Microsoft.Extensions.Hosting;

namespace ProdutosFinanceiros.Application.Services;

public class EmailNotificationService : IHostedService
{
    private readonly string _senderEmail;

    public EmailNotificationService()
    {
        _senderEmail = "produtofinanceiro@xp.com";
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Email notification service has started.");
        return StartSendingNotifications(cancellationToken);
    }

    public async Task StartSendingNotifications(CancellationToken cancellationToken)
    {
        await Task.Run(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var currentTime = DateTime.Now.TimeOfDay;
                var nextNotificationTime = new TimeSpan(9, 0, 0); // Set the notification time to 9 o'clock

                // If the current time is already past the notification time for today,
                // calculate the time until the next notification time for tomorrow
                if (currentTime > nextNotificationTime)
                {
                    nextNotificationTime = nextNotificationTime.Add(TimeSpan.FromDays(1));
                }

                var timeUntilNextNotification = nextNotificationTime - currentTime;
                Console.WriteLine($"Next notification email in: {timeUntilNextNotification}");

                // Wait until the next notification time or until cancellation is requested
                await Task.Delay(timeUntilNextNotification, cancellationToken);

                // Check if cancellation is requested before sending the notification email
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                // Send the notification email
                await SendNotificationEmail();

                // Wait for 24 hours before sending the next notification or until cancellation is requested
                await Task.Delay(TimeSpan.FromHours(24), cancellationToken);
            }
        }, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Email notification service has stopped");
        return Task.CompletedTask;
    }

    private async Task SendNotificationEmail()
    {
        // Mock email sending for demonstration purposes
        string recipientEmail = "recipient@example.com";
        string subject = "Notification";
        string body = await GetEmailBodyMessage();

        var emailDetails = new
        {
            SenderEmail = _senderEmail,
            RecipientEmail = recipientEmail,
            Subject = subject,
            Body = body
        };

        string email = Newtonsoft.Json.JsonConvert.SerializeObject(emailDetails);
        Console.WriteLine(email);
    }

    private async Task<string> GetEmailBodyMessage()
    {
        StringBuilder message = new StringBuilder();
        message.AppendLine("Hello,");
        message.AppendLine("This is a notification email.");
        message.AppendLine("Please take note of the following information:");
        message.AppendLine("- Notification 1");
        message.AppendLine("- Notification 2");
        message.AppendLine("- Notification 3");
        return message.ToString();
        
    }
}

