using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminRole
{
    public void AdminRoles()
    {
        while (true)
        {
            adminChoices.DisplayAdminChoices();
            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 6 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 1:
                        {
                            AddUser();
                            break;
                        }
                    case 2:
                        {
                            adminGetRole.AdminGetRoles();
                            break;
                        }
                    case 3:
                        {
                            UpdateUser();
                            break;
                        }
                    case 4:
                        {
                            adminDeleteRole.AdminDeleteRoles();
                            break;
                        }
                    case 5:
                        {
                            adminSendNotificationRole.AdminSendNotificationRoles();
                            break;
                        }
                    case 6:
                        {
                            adminGetNotificationRole.AdminGetNotificationRoles();
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