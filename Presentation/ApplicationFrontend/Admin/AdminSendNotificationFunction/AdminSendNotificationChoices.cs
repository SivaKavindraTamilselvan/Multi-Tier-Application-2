using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminSendNotificationRole
{
    public void AdminSendNotificationRoles()
    {
        adminChoices.DisplayAdminDeliverMessageChoices();
        int typechoice;
        while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 2 || typechoice < 0)
        {
            Console.WriteLine("Enter Vaild Input");
        }
        try
        {
            switch (typechoice)
            {
                case 1:
                    {
                        DeliverNotificationByEmail();
                        break;
                    }
                case 2:
                    {
                        DeliverNotificationByPhoneNumber();
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