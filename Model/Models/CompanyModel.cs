namespace NotificationAppModelLibrary;

public class Company
{
    public string? Name {get;set;}
    public string? Email {get;set;}
    public string? PhoneNumber{get;set;}
    public string[] Services  = new string[2];

    public Company()
    {
        Name = Environment.GetEnvironmentVariable("CompanyName");
        Email = Environment.GetEnvironmentVariable("CompanyEmail");
        PhoneNumber = Environment.GetEnvironmentVariable("CompanyPhoneNumber");
        Services[0] = "Email";
        Services[1] = "SMS";
    }
    public override string ToString()
    {
        return $"CompanyDetails\nComapany Name : {Name}\nEmail : {Email}\nPhoneNumber : {PhoneNumber}\nServices : {Services[0]} , {Services[1]}";
    }
}
