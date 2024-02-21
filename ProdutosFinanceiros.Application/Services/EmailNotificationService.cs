using System.Text;
using Microsoft.Extensions.Hosting;
using ProdutosFinanceiros.Domain.Interfaces;

namespace ProdutosFinanceiros.Application.Services;

public class EmailNotificationService : BackgroundService, IHostedService
{
    private readonly IInvestmentWalletFinancialProductRepository _investmentWalletFinancialProductRepository;
    private readonly IUserRepository _userRepository;
    private readonly string _senderEmail;

    public EmailNotificationService(
        IInvestmentWalletFinancialProductRepository investmentWalletFinancialProductRepository,
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _investmentWalletFinancialProductRepository = investmentWalletFinancialProductRepository;
        _senderEmail = "produtofinanceiro@xp.com";
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Email notification service has started.");
        return ExecuteAsync(cancellationToken);
    }

    public void StartSendingNotifications(CancellationToken cancellationToken)
    {
        Task.Run(() =>
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
                Task.Delay(timeUntilNextNotification, cancellationToken).GetAwaiter().GetResult();

                // Check if cancellation is requested before sending the notification email
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                // Send the notification email
                SendNotificationEmail().GetAwaiter().GetResult();

                // Wait for 24 hours before sending the next notification or until cancellation is requested
                Task.Delay(TimeSpan.FromHours(24), cancellationToken).GetAwaiter().GetResult();
            }
        });
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Dispose();
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
        var managers = await _userRepository.GetManagers();
        foreach (var manager in managers)
        {
            var closingFinancialProducts = await _investmentWalletFinancialProductRepository.GetClosingFinancialProducts(manager.Id);
            message.AppendLine("Hello,");
            message.AppendLine("This is a notification email.");
            message.AppendLine("Please take note of the following information:");
            foreach (var entry in closingFinancialProducts)
            {
                message.AppendLine(entry);
            }
        }
        return message.ToString();
        
    }

    protected override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        StartSendingNotifications(cancellationToken);
        return Task.CompletedTask;
    }
}

