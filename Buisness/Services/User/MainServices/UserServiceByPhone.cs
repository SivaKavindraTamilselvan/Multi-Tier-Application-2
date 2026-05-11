using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppBuisnessLayerLibrary.Services;
public partial class UserService : IUserService
{
    public User? GetUserByPhoneNumber(string phonenumber)
    {
        var UserList = userRepo.GetAll();
        //if no user is registered
        if(UserList == null)
        {
            throw new UserNotFoundException();
        }
        foreach (var item in UserList)
        {
            if (item.PhoneNumber == phonenumber)
            {
                return item;
            }
        }
        return null;
    }

    public List<User> DeleteUserByPhoneNumber(string phonenumber)
    {
        var userList = userRepo.DeleteByPhoneNumber(phonenumber);
        //if no user is registered
        if(userList == null)
        {
            throw new UserNotFoundException();
        }
        foreach(var user in userList)
        {
            SendDeleteNotification(user);
        }
        return userList;
    }
}