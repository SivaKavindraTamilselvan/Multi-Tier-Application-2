using NotificationAppModelLibrary;
using DotNetEnv;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayerLibrary.Services;
using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppDataAccessLibrary.Repositories;
using NotificationAppPresentationLayer.Application;

internal class Program
{
    static void Main(string[] args)
    {
        Env.Load();

        IUserRepository userRepo = new UserRepository();
        INotificationRepository notificationRepo = new NotificationRepository();

        INotificationSender email = new EmailService(notificationRepo);
        INotificationSender sms = new SMSService(notificationRepo);

        IUserService userService = new UserService(userRepo,email,sms);

        INotificationService notificationService = new NotificationService(notificationRepo, email, sms);

        AdminRole adminRole = new AdminRole(userService, notificationService);
        UserRole userRole = new UserRole(userService,notificationService);
        
        Company company = new Company();

        Console.WriteLine("------------------------------------------------");
        Console.WriteLine(company);
        Console.WriteLine("------------------------------------------------");

        HomePage homePage = new HomePage(adminRole,userRole);
        homePage.RoleSelection();
    }
}