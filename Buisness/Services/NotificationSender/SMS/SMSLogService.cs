namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class SMSService : NotificationSenderService
{
    //log the information in console
    public override void LogNotification()
    {
        string CompanyPhoneNumber = Environment.GetEnvironmentVariable("CompanyPhoneNumber") ?? "";
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Logging the Information - SMS Service");
        Console.WriteLine();
        Console.WriteLine($"The SMS Services\nFrom : {CompanyPhoneNumber}\nTo : {user.PhoneNumber}\nStatus : {status}\nDate & Time : {dateTime}\nMessage :\n{message}");
        Console.WriteLine("---------------------------------------------");
    }
}