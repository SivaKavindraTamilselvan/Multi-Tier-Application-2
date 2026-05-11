using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminSendNotificationRole
{
    private readonly IUserService userService;
    private readonly INotificationService notificationService;
    private InputsCheck inputCheck = new InputsCheck();
    private AdminChoices adminChoices = new AdminChoices();
    public AdminSendNotificationRole(IUserService userService, INotificationService notificationService)
    {
        this.userService = userService;
        this.notificationService = notificationService;
    }
}