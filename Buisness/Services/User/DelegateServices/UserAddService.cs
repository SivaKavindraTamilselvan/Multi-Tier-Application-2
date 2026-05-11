using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayerLibrary.Delegates;

namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class UserService : IUserService
{
    private User? createdUser;
    public User? AddUser()
    {
        //delegate function is added
        AddUserOperation addUserOperation = null!;

        addUserOperation += AddNewUser;
        addUserOperation += SendAddNotification;

        addUserOperation.Invoke();

        return createdUser;
    }
    public void AddNewUser()
    {
        User user = new User();

        Console.WriteLine("Enter Your Name");
        string name = Console.ReadLine() ?? "";
        while (name.Trim() == "")
        {
            Console.WriteLine("Inavlid Name.Name Should Not be Empty.Enter Valid Name");
            name = Console.ReadLine() ?? "";
        }

        Console.WriteLine("Enter Your Email");
        string email = inputsCheck.EmailInputs();
        if (GetUserByEmail(email) != null)
        {
            Console.WriteLine("Aldready Email is Registered with This Email");
            createdUser = null!;
            return;
        }

        Console.WriteLine("Enter Your PhoneNumber");
        string phone = inputsCheck.PhoneNumberInputs();
        //user detailed added to the object
        user.Name = name;
        user.Email = email;
        user.PhoneNumber = phone;

        createdUser = userRepo.Create(user);

        Console.WriteLine("User Added Successfully. Wait until the Email && SMS is sent!!");
    }

    public void SendAddNotification()
    {
        if (createdUser == null)
        {
            return;
        }
        string message = $"Successfully created an account with the details\nUserId : {createdUser.userId}\nName : {createdUser.Name}\nPhoneNumber : {createdUser.PhoneNumber}\nEmail : {createdUser.Email}\nThank You!";
        emailService.Send(message, createdUser, "Email");
        smsService.Send(message, createdUser, "SMS");
    }
}