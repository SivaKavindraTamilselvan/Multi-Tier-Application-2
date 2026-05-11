using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppBuisnessLayerLibrary.Services;
public partial class UserService : IUserService
{
    public User? GetUserByEmail(string email)
    {
        var UserList = userRepo.GetAll();
        if(UserList == null)
        {
            throw new UserNotFoundException();
        }
        foreach (var item in UserList)
        {
            if (item.Email == email)
            {
                return item;
            }
        }
        return null;
    }
    public User? DeleteUserByEmail(string email)
    {
        var user = userRepo.DeleteByEmail(email);
        if(user == null)
        {
            throw new UserNotFoundException();
        }
        SendDeleteNotification(user);
        return user;
    }
}
