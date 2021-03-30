using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ArkSE.DAL.DataObjects;
using ArkSE.DAL.DataServices;

namespace ArkSE.BL.ViewModels.OfficialServers
{
    public class OfficialServersViewModel : BaseViewModel
    {
        public IEnumerable<OfficialServerObjectViewModel> OfficialServers
        {
            get => Get<IEnumerable<OfficialServerObjectViewModel>>();
            set => Set(value);
        }

        public ICommand ShowServerInfoCommand => MakeCommand(ShowServerInfoCommandImplementation);
        public void ShowServerInfoCommandImplementation(object serverObject)
        {
            NavigateTo(Pages.ServerInfo, mode: NavigationMode.Modal, navParams:
                new Dictionary<string, object>()
                {
                    {"SelectedServer", serverObject}
                });
        }

        protected override async Task LoadDataAsync()
        {
            if (!IsConnected)
            {
                State = PageState.NoInternet;
                return;
            }

            var result = await DataServices.OfficialServersDataService.GetOfficialServers(CancellationToken);
            OfficialServers = result.Data.Select(serverObject => new OfficialServerObjectViewModel(serverObject));
        }
    }
}
