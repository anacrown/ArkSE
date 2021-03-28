using System.Collections.ObjectModel;
using System.Windows.Input;
using SourceQuery;

namespace ArkSE.BL.ViewModels.OfficialServers
{
    public class OfficialServersViewModel: BaseViewModel
    {
        private ObservableCollection<GameServer> OfficialServers { get; set; } = new ObservableCollection<GameServer>();

	    public ICommand ShowServerInfoCommand => MakeCommand(ShowServerInfoCommandImplementation);

	    void ShowServerInfoCommandImplementation()
	    {
		    // SettingService.HotelId = "exampleHotelId";
		    NavigateTo(Pages.ServerInfo, mode:NavigationMode.Master);
	    }
    }
}
