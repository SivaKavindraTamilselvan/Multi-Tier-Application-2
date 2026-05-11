using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminGetNotificationRole
{
    public void AdminGetNotificationRoles()
    {

        adminChoices.DisplayAdminNotificationChoices();
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
                        GetNotificationsById();
                        break;
                    }
                case 2:
                    {
                        GetNotificationsByUserId();
                        break;
                    }
                case 3:
                    {
                        GetAllNotification();
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