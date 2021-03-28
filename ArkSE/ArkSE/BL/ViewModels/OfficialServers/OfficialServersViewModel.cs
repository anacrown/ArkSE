using System.Windows.Input;

namespace ArkSE.BL.ViewModels.OfficialServers
{
    public class OfficialServersViewModel: BaseViewModel
    {
	    public ICommand ShowServerInfoCommand => MakeCommand(ShowServerInfoCommandImplementation);

	    void ShowServerInfoCommandImplementation()
	    {
		    // SettingService.HotelId = "exampleHotelId";
		    NavigateTo(Pages.ServerInfo, mode:NavigationMode.Master);
	    }
    }
}
