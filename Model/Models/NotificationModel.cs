namespace NotificationAppModelLibrary;

public class Notification
{
    public int notificationId {get;set;}
    public int userId {get;set;}

    public string userEmail {get;set;} = "";
    public string message {get;set;} = "";
    public string service {get;set;} = "";
    public string status {get;set;}= "pending";
    public DateTime? datetime {get;set;}

    public override string ToString()
    {
        return $"NotificationId : {notificationId}\nUserId : {userId}\nUserEmail : {userEmail}\nMessage : {message}\nService : {service}\nStatus : {status}\nDateTime : {datetime}";
    }
}