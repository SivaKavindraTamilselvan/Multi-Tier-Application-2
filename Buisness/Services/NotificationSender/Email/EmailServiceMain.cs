using System.Net;
using System.Net.Mail;

namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class EmailService : NotificationSenderService
{
    public EmailService(INotificationRepository repo) : base(repo)
    {
    }
    public override void SendNotification()
    {
        try
        {
            //to get the data from env for security in version control
            string fromEmail = Environment.GetEnvironmentVariable("CompanyEmail") ?? "";
            string? fromName = Environment.GetEnvironmentVariable("CompanyName") ?? "";

            string? toEmail = user.Email ?? "";
            string? toName = user.Name ?? "";

            var from = new MailAddress(fromEmail, fromName);
            var to = new MailAddress(toEmail, toName);

            string? password = Environment.GetEnvironmentVariable("Password") ?? "";

            //smtp request for sending the email
            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(from.Address, password),
                EnableSsl = true
            };

            var mail = new MailMessage(from, to)
            {
                Subject = "Notification",
                Body = message,
                IsBodyHtml = true
            };

            smtp.Send(mail);

            status = "Sent";
            dateTime = DateTime.Now;

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Email Service");
            Console.WriteLine("Email Sent Successfully");
            Console.WriteLine("---------------------------------------------");

        }
        catch (Exception ex)
        {
            status = "Failed" + ex.Message;
        }
    }
}