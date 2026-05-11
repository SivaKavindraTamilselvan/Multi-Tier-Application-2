using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppBuisnessLayerLibrary.Services;
public partial class UserService : IUserService
{
    public User GetUserById(int id)
    {
        var user = userRepo.Get(id);
        if(user == null)
        {
            throw new UserNotFoundException();
        }
        return user;
    }
    public User? DeleteUserById(int id)
    {
        var user = userRepo.Get(id);
        if(user == null)
        {
            throw new UserNotFoundException();
        }
        deletedUser = user;
        DeleteDelegate();
        return deletedUser;
    }
    public User? UpdateUserById(int userId)
    {
        updateUser = GetUserById(userId);
        if (updateUser == null)
        {
            throw new UserNotFoundException();
        }
        UpdateDelegate();

        return updateUser;
    }
}