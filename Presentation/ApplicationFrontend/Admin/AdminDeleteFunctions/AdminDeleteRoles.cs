using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminDeleteRole
{
    private readonly IUserService userService;
    private InputsCheck inputCheck = new InputsCheck();
    private AdminChoices adminChoices= new AdminChoices();
    public AdminDeleteRole(IUserService userService)
    {
        this.userService = userService;
    }
}