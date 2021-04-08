using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ArkSE.DAL.DataObjects;
using ArkSE.DAL.DataServices;

namespace ArkSE.UI.Pages.DedicatedServersList
{
    public class DedicatedServersListViewModel : BaseViewModel
    {
        #region Navigate

        public void NavigateToDedicatedServersList(OfficialServerObject serverObject)
        {
            NavigateTo(ArkSE.Pages.DedicatedServerInfo, mode: NavigationMode.Modal, navParams:
                new Dictionary<string, object>()
                {
                    {"SelectedServer", serverObject}
                });
        }

        #endregion

        public IEnumerable<OfficialServerObject> OfficialServers
        {
            get => Get<IEnumerable<OfficialServerObject>>();
            set => Set(value);
        }

        protected override async Task LoadDataAsync()
        {
            if (!IsConnected)
            {
                State = PageState.NoInternet;
                return;
            }

            ShowLoading();
            var result = await DataServices.OfficialServersDataService.GetOfficialServers(CancellationToken);

            OfficialServers = result.Data;
            HideLoading();
        }
    }
}