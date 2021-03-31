using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArkSE.BL.ViewModels.OfficialServers;
using ArkSE.DAL;
using ArkSE.DAL.DataObjects;
using ArkSE.DAL.DataServices;

namespace ArkSE.BL.ViewModels.ServerInfo
{
    public class ServerInfoViewModel : BaseViewModel
    {
        public OfficialServerObject ServerObject
        {
            get => Get<OfficialServerObject>();
            set => Set(value);
        }

        public IEnumerable<OfficialGameServerObject> OfficialGameServerObjects
        {
            get => Get<IEnumerable<OfficialGameServerObject>>();
            set => Set(value);
        }

        public override void OnSetNavigationParams(Dictionary<string, object> navigationParams)
        {
            if (navigationParams.TryGetValue("SelectedServer", out var paramValue) &&
                paramValue is OfficialServerObject selectedServer)
                ServerObject = selectedServer;

            base.OnSetNavigationParams(navigationParams);
        }

        protected override async Task LoadDataAsync()
        {
            if (!IsConnected)
            {
                State = PageState.NoInternet;
                return;
            }

            ShowLoading();
            var result = await DataServices.OfficialServersDataService.GetOfficialGameServerObjects(ServerObject, CancellationToken);
            HideLoading();

            if (result.Status == RequestStatus.Ok)
            {
                OfficialGameServerObjects = result.Data;
                if (!OfficialGameServerObjects.Any())
                {
                    ShowToast("Failed to find game servers", true);
                }
            }
        }
    }
}
