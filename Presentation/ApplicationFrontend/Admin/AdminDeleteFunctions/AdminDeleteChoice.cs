using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminDeleteRole
{
    public void AdminDeleteRoles()
    {
        adminChoices.DisplayDeleteAdminChoices();
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
                        DeleteUserById();
                        break;
                    }
                case 2:
                    {
                        DeleteUserByEmail();
                        break;
                    }
                case 3:
                    {
                        DeleteUserByPhoneNumber();
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