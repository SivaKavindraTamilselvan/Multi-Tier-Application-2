using NotificationAppBuisnessLayerLibrary.Validation;

namespace NotificationAppBuisnessLayer.Inputs;

public class InputsCheck
{
    //email input is checked and validated
    public string EmailInputs()
    {
        string email = Console.ReadLine() ?? string.Empty;
        //loop until valid entry is entered
        while(true)
        {
            try
            {
                //call validation function
                EmailValidation.isValidEmail(email);
                return email;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter Valid Email Address Again");
                email = Console.ReadLine() ?? "";
            }
        }
    }
    public string PhoneNumberInputs()
    {
        string phone = Console.ReadLine() ?? string.Empty;
        //loop until valid entry is entered
        while (true)
        {
            try
            {
                //call validation function
                PhoneNumberValidation.isValidPhoneNumber(phone);
                return phone;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter Valid Phone Number Again");
                phone = Console.ReadLine() ?? "";
            }
        }
    }

    public string MessageInputs(string receiver, string service)
    {
        Console.WriteLine($"Enter Message To Send To {receiver}");

        string message = Console.ReadLine() ?? string.Empty;
        //loop until valid entry is entered
        while (true)
        {
            try
            {
                //call validation function
                MessageValidation.ValidateMessage(message, service);
                return message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter Valid Message Again");
                message = Console.ReadLine() ?? "";
            }
        }
    }

    public int IdInputs()
    {
        Console.WriteLine("Enter Id");
        int id;
        //loop until valid entry is entered
        while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
        {
            Console.WriteLine("Enter Vaild Input");
        }
        return id;
    }
}