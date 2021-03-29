using System;
using System.Collections.Generic;
using System.Text;
using ArkSE.DAL.DataObjects;

namespace ArkSE.BL.ViewModels.ServerInfo
{
    public class ServerInfoViewModel : BaseViewModel
    {
        public OfficialServerObject ServerObject
        {
            get => Get<OfficialServerObject>();
            set => Set(value);
        }

        public override void OnSetNavigationParams(Dictionary<string, object> navigationParams)
        {
            if (navigationParams.TryGetValue("SelectedServer", out var paramValue) &&
                paramValue is OfficialServerObject selectedServer)
                ServerObject = selectedServer;

            base.OnSetNavigationParams(navigationParams);
        }
    }
}
