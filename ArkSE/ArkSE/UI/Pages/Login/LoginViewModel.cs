using System.Windows.Input;

namespace ArkSE.UI.Pages.Login
{
    public class LoginViewModel: BaseViewModel
    {
	    public ICommand LoginCommand => MakeCommand(LoginCommandImplementation);

	    void LoginCommandImplementation()
	    {
		    // SettingService.HotelId = "exampleHotelId";
		    NavigateTo(ArkSE.Pages.FavServers, mode:NavigationMode.Master);
	    }
    }
}
