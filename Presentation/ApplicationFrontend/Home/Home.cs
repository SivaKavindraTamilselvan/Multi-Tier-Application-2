using NotificationAppModelLibrary;

namespace NotificationAppPresentationLayer.Application;
public class HomePage
{
    private readonly AdminRole adminRole;
    private readonly UserRole userRole;
    public HomePage(AdminRole _adminRole,UserRole _userRole)
    {
        adminRole = _adminRole;
        userRole = _userRole;
    }
    public void RoleSelection()
    {
        while (true)
        {

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 For Company");
            Console.WriteLine("Enter 2 For User");
            Console.WriteLine("Enter 0 To Quit");
            Console.WriteLine("------------------------------------------------");
            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice <0 || typechoice >3)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 1:
                        {
                            adminRole.AdminRoles();
                            break;
                        }
                    case 2:
                        {
                            userRole.UserRoles();
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