using System.Collections.Generic;
using System.Windows.Input;
using ArkSE.DAL.DataObjects;
using ArkSE.Helpers;

namespace ArkSE.UI.Pages.FavServers
{
    public class FavServersViewModel: BaseViewModel
    {
        #region Navigate

        public void NavigateToGameServerInfo(OfficialGameServerObject serverObject)
        {
            NavigateTo(ArkSE.Pages.GameServerInfo, mode: NavigationMode.Modal, navParams:
                new Dictionary<string, object>()
                {
                    {"SelectedServer", serverObject}
                });
        }

        #endregion

        public ICommand ServerInfoCommand => MakeCommand(ServerInfoCommandImplementation);

        private void ServerInfoCommandImplementation()
        {
            NavigateTo(ArkSE.Pages.DedicatedServersList, mode: NavigationMode.Modal);
        }

        public IEnumerable<OfficialGameServerObject> OfficialGameServerObjects => SettingService.FavServers;
    }
}
