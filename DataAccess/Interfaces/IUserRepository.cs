using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppModelLibrary;

//interfcae for notification repo additional repo other tha IRepo
public interface IUserRepository : IRepository<int, User>
{
    public User? DeleteByEmail(string email);
    public List<User> DeleteByPhoneNumber(string PhoneNumber);
}