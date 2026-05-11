using System.Text.RegularExpressions;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppBuisnessLayerLibrary.Validation;

public class EmailValidation
{
    //implementation of email validation by using regex pattern
    public static void isValidEmail(string email)
    {
        string checkEmail=email.Trim();

        //regex pattern
        string pattern=@"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if(!Regex.IsMatch(checkEmail, pattern, RegexOptions.IgnoreCase)){
            throw new EmailException("Email Entered Is Not Valid. Your Account is Not Created");
        }        
    }
}