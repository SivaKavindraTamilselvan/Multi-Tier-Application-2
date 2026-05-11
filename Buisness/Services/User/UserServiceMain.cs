using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class UserService : IUserService
{
    private readonly IUserRepository userRepo;
    private readonly INotificationSender emailService;
    private readonly INotificationSender smsService;
    InputsCheck inputsCheck = new InputsCheck();
    public UserService(IUserRepository repo,INotificationSender email,INotificationSender sms)
    {
        userRepo = repo;
        emailService = email;
        smsService = sms;
    }
    public void PrintAllUsers()
    {
        var UserList = userRepo.GetAll();
        //if no user found in the list
        if(UserList.Count == 0)
        {
            throw new UserNotFoundException();
        }
        foreach (var item in UserList)
        {
            Console.WriteLine("Information of the user");
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}
