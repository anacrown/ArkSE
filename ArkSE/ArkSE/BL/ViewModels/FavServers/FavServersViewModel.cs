using System.Windows.Input;

namespace ArkSE.BL.ViewModels.FavServers
{
    public class FavServersViewModel: BaseViewModel
    {
	    public ICommand ServerInfoCommand => MakeCommand(ServerInfoCommandImplementation);

        private void ServerInfoCommandImplementation()
        {
            NavigateTo(Pages.ServerInfo, mode: NavigationMode.Modal);
        }
    }
}
