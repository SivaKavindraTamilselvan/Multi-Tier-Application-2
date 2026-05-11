using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminGetRole
{
    public void AdminGetRoles()
    {

        adminChoices.DisplayGetAdminChoices();
        int typechoice;
        while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 4 || typechoice < 0)
        {
            Console.WriteLine("Enter Vaild Input");
        }
        try
        {
            switch (typechoice)
            {
                case 1:
                    {
                        GetUserById();
                        break;
                    }
                case 2:
                    {
                        GetUserByEmail();
                        break;
                    }
                case 3:
                    {
                        GetUserByPhoneNumber();
                        break;
                    }
                case 4:
                    {
                        GetAll();
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