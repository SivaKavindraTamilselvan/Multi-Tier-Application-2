using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminRole
{
    public void AddUser()
    {
        var user = userService.AddUser();
        if (user == null)
        {
            throw new UserNotFoundException();
        }
    }
    public void UpdateUser()
    {
        int userid = inputCheck.IdInputs();
        var user = userService.UpdateUserById(userid);
        //display if no user with the id found
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        Console.WriteLine("Updated User Details");
        Console.WriteLine(user);
    }
}