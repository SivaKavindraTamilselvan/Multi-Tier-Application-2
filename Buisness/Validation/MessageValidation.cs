using System.Reflection.Metadata;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppBuisnessLayerLibrary.Validation;

public class MessageValidation
{
    public static bool ValidateMessage(string message,string service)
    {
        message = message.Trim();
        if(message.IsWhiteSpace())
        {
            throw new MessageException("Message that needed to be sent for notification should not be empty");
        }
        if(message.Length<5)
        {
            throw new MessageException("Message length needed to be more than 5");
        }
        if(message.Length>160 && service.Equals("SMS"))
        {
            throw new MessageException("Message that needed to be sent via SMS should not be greater than 160");
        }
        return true;
    }
}