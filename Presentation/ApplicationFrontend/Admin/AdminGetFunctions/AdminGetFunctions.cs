using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminGetRole
{
    public void GetUserById()
    {
        int userid = inputCheck.IdInputs();
        var user = userService.GetUserById(userid);
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        Console.WriteLine("Information of the user");
        Console.WriteLine(user);
    }
    public void GetUserByEmail()
    {
        Console.WriteLine("Enter the Email To Get The User");
        //Inputs given and validated - check inputcheck file
        string email = inputCheck.EmailInputs();
        var user = userService.GetUserByEmail(email);
        //display if no user with the email id found
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        Console.WriteLine("Information of the user");
        Console.WriteLine(user);
    }
    public void GetUserByPhoneNumber()
    {
        Console.WriteLine("Enter the PhoneNumber To Get The User");
        //Inputs given and validated - check inputcheck file
        string phone = inputCheck.PhoneNumberInputs();
        var user = userService.GetUserByPhoneNumber(phone);
        //display if no user with the phone number found
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        Console.WriteLine("Information of the user");
        Console.WriteLine(user);
    }
    public void GetAll()
    {
        userService.PrintAllUsers();
    }
}