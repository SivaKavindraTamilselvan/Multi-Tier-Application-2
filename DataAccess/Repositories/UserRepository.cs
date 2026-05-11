using NotificationAppModelLibrary;
namespace NotificationAppDataAccessLibrary.Repositories;

public class UserRepository : AbstractRepository<int,User>
{
    static int userId = 0;
    //override the create function
    public override User Create(User user)
    {
        user.userId = ++userId;
        items.Add(userId,user);
        return user;
    }
}