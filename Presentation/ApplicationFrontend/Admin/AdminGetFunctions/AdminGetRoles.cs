using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminGetRole
{
    private readonly IUserService userService;
    private InputsCheck inputCheck = new InputsCheck();
    private AdminChoices adminChoices = new AdminChoices();
    public AdminGetRole(IUserService userService)
    {
        this.userService=userService;
    }
}