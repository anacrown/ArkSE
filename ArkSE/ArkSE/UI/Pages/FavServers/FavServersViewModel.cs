using System.Windows.Input;

namespace ArkSE.UI.Pages.FavServers
{
    public class FavServersViewModel: BaseViewModel
    {
	    public ICommand ServerInfoCommand => MakeCommand(ServerInfoCommandImplementation);

        private void ServerInfoCommandImplementation()
        {
            NavigateTo(ArkSE.Pages.DedicatedServersList, mode: NavigationMode.Modal);
        }
    }
}
