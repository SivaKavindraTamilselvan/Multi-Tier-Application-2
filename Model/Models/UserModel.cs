namespace NotificationAppModelLibrary;

public class User
{
    public int userId {get;set;}
    public string? Name {get;set;}
    public string? Email {get;set;}
    public string? PhoneNumber{get;set;}

    public User()
    {
        Name = "";
        Email = "";
        PhoneNumber = "";
    }
    public User(string name,string email,string phonenumber)
    {
        Name = name;
        Email = email;
        PhoneNumber = phonenumber;
    }

    public override string ToString()
    {
        return $"UserId : {userId}\nName : {Name}\nEmail : {Email}\nPhoneNumber : {PhoneNumber}";
    }
}