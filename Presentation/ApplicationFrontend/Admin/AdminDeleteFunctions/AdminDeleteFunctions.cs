using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminDeleteRole
{
    public void DeleteUserByEmail()
    {
        Console.WriteLine("Enter the Email To Delete The User");
        //Inputs given and validated - check inputcheck file
        string email = inputCheck.EmailInputs();
        var user = userService.DeleteUserByEmail(email);
        //display if no user with the email id found
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        Console.WriteLine("Information of deleted user");
        Console.WriteLine(user);
    }
    public void DeleteUserById()
    {
        int userid = inputCheck.IdInputs();
        var user = userService.DeleteUserById(userid);
        //display if no user with the id found
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        Console.WriteLine("Information of deleted user");
        Console.WriteLine(user);
    }
    public void DeleteUserByPhoneNumber()
    {
        Console.WriteLine("Enter the PhoneNumber To Delete The User");
        //Inputs given and validated - check inputcheck file
        string phone = inputCheck.PhoneNumberInputs();
        var user = userService.DeleteUserByPhoneNumber(phone);
        //display if no user with the phone number found
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        Console.WriteLine("Deleted User List With Phone Number");
        foreach (var item in user)
        {
            Console.WriteLine("Information of deleted user");
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}