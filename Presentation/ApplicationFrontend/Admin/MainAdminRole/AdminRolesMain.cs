using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminRole
{
    private readonly IUserService userService;
    private readonly INotificationService notificationService;
    private readonly AdminDeleteRole adminDeleteRole;
    private readonly AdminGetNotificationRole adminGetNotificationRole;
    private readonly AdminGetRole adminGetRole;
    private readonly AdminSendNotificationRole adminSendNotificationRole;
    private InputsCheck inputCheck = new InputsCheck();
    private AdminChoices adminChoices = new AdminChoices();
    public AdminRole(IUserService userService, INotificationService notificationService)
    {
        this.userService = userService;
        this.notificationService = notificationService;

        adminDeleteRole = new AdminDeleteRole(userService);
        adminGetNotificationRole = new AdminGetNotificationRole(userService,notificationService);
        adminGetRole = new AdminGetRole(userService);
        adminSendNotificationRole = new AdminSendNotificationRole(userService,notificationService);
    }
}