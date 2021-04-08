using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ArkSE.DAL.DataObjects;
using ArkSE.Helpers;

namespace ArkSE.UI.Pages.GameServerInfo
{
    public class GameServerInfoViewModel : BaseViewModel
    {
        public override void OnSetNavigationParams(Dictionary<string, object> navigationParams)
        {
            if (navigationParams.TryGetValue("SelectedServer", out var paramValue) &&
                paramValue is OfficialGameServerObject selectedServer)
                GameServerObject = selectedServer;

            base.OnSetNavigationParams(navigationParams);
        }

        public ICommand AddToFavoriteCommand => MakeCommand(AddToFavoriteCommandImplementation);

        private void AddToFavoriteCommandImplementation()
        {
            SettingService.FavServers.Add(GameServerObject);
        }

        public OfficialGameServerObject GameServerObject
        {
            get => Get<OfficialGameServerObject>();
            set => Set(value);
        }
    }
}
