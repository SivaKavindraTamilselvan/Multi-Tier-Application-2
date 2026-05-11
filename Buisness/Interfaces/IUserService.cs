using NotificationAppModelLibrary;
namespace NotificationAppBuisnessLayerLibrary.Interfaces;

//user service interface
public interface IUserService
{
    public User? AddUser();
    public void PrintAllUsers();
    public User? GetUserById(int id);
    public User? GetUserByEmail(string email);
    public User? GetUserByPhoneNumber(string phonenumber);
    public List<User>? DeleteUserByPhoneNumber(string phonenumber);
    public User? DeleteUserByEmail(string email);
    public User? UpdateUserById(int userid);
    public User? DeleteUserById(int userid);
}