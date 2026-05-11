using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayerLibrary.Delegates;
using NotificationAppModelLibrary.Exceptions;


namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class UserService : IUserService
{
   public void SendDeleteNotification(User deletedUser)
    {
        string message = $"Successfully deleted your account with the details\nName : {deletedUser.Name}\nPhoneNumber : {deletedUser.PhoneNumber}\nEmail : {deletedUser.Email}\nThank You!";
        emailService.Send(message, deletedUser,"Email");
        smsService.Send(message, deletedUser,"SMS");
    }
}