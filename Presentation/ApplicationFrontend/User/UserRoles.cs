using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;
using NotificationAppBuisnessLayerLibrary.Services;

namespace NotificationAppPresentationLayer.Application;

public partial class UserRole
{
    private readonly IUserService userService;
    private readonly INotificationService notificationService;
    private InputsCheck inputCheck = new InputsCheck();
    private UserChoices userChoices = new UserChoices();
    public UserRole(IUserService userService, INotificationService notificationService)
    {
        this.userService = userService;
        this.notificationService = notificationService;
    }
    public void UserRoles()
    {
        while (true)
        {
            userChoices.DisplayUserChoices();
            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 3 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 1:
                        {
                            GetNotificationsByUserId();
                            break;
                        }
                    case 2:
                        {
                            GetNotificationsByUserIdAndService("Email");
                            break;
                        }
                    case 3:
                        {
                            GetNotificationsByUserIdAndService("SMS");
                            break;
                        }
                    case 0:
                        {
                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}