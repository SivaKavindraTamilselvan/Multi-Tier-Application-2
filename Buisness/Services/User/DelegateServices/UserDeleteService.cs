using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayerLibrary.Delegates;
using NotificationAppModelLibrary.Exceptions;


namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class UserService : IUserService
{
    DeleteUserOperation? deleteUserOperation;
    private User deletedUser = null!;
    public void DeleteDelegate()
    {
        //delegate function is added
        deleteUserOperation = null;

        deleteUserOperation += DeleteUser;
        deleteUserOperation += SendDeleteNotification;

        deleteUserOperation?.Invoke();
    }
    public void DeleteUser()
    {
        userRepo.Delete(deletedUser.userId);
        Console.WriteLine("User Deleted Successfully ! Wait for the Email && SMS to be sent");
    }
    public void SendDeleteNotification()
    {
        //to avoid notification if not deleted
        if(deletedUser == null)
        {
            throw new UserNotFoundException();
        }
        string message = $"Successfully deleted your account with the details\nName : {deletedUser.Name}\nPhoneNumber : {deletedUser.PhoneNumber}\nEmail : {deletedUser.Email}\nThank You!";
        emailService.Send(message, deletedUser,"Email");
        smsService.Send(message, deletedUser,"SMS");
    }
}