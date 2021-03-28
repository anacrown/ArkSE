using System.Windows.Input;

namespace ArkSE.BL.ViewModels.Login
{
    public class LoginViewModel: BaseViewModel
    {
	    public ICommand LoginCommand => MakeCommand(LoginCommandImplementation);

	    void LoginCommandImplementation()
	    {
		    // SettingService.HotelId = "exampleHotelId";
		    NavigateTo(Pages.FavServers, mode:NavigationMode.Master);
	    }
    }
}
