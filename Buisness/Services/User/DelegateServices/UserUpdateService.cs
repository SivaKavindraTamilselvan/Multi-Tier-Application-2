using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayerLibrary.Delegates;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class UserService : IUserService
{
    UpdateUserOperation? updateUserOperation;
    private User updateUser=null!;

    public void UpdateDelegate()
    {
        //delegate function is added
        updateUserOperation = null;

        updateUserOperation += UpdateUser;
        updateUserOperation += SendUpdateNotification;

        updateUserOperation?.Invoke();
    }
    public void UpdateUser()
    {
        Console.WriteLine("Enter Your Name That Needed To Be Updated");
        string name = Console.ReadLine() ?? "";
        while (name.Trim() == "")
        {
            Console.WriteLine("Inavlid Name.Name Should Not be Empty.Enter Valid Name");
            name = Console.ReadLine() ?? "";
        }

        Console.WriteLine("Enter Your Email That Needed To Be Updated");
        string email = inputsCheck.EmailInputs();
        
        //to avoid aldready registered email to be entered
        if(GetUserByEmail(email) != null && updateUser.Email!=email)
        {
            Console.WriteLine("Aldready Email is Registered with This Email");
            return;
        }

        Console.WriteLine("Enter Your PhoneNumber That Needed To Be Updated");
        string phone = inputsCheck.PhoneNumberInputs();
        
        //user detailed stored in a object
        updateUser.Name = name;
        updateUser.Email = email;
        updateUser.PhoneNumber = phone;
        var user = userRepo.Update(updateUser.userId,updateUser);
        if(user == null)
        {
            throw new UserNotFoundException();
        }
        updateUser = user;
        Console.WriteLine("User Updated Successfully. Wait for the Email && SMS to be sent!!");
    }

    public void SendUpdateNotification()
    {
        //to avoid notification if not updated
        if(updateUser == null)
        {
            throw new UserNotFoundException();
        }
        string message = $"Successfully updated your account with the details\nName : {updateUser.Name}\nPhoneNumber : {updateUser.PhoneNumber}\nEmail : {updateUser.Email}\nThank You!";
        emailService.Send(message, updateUser,"Email");
        smsService.Send(message, updateUser,"SMS");
    }
}