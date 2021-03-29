using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ArkSE.DAL.DataObjects;
using ArkSE.DAL.DataServices;
using SourceQuery;

namespace ArkSE.BL.ViewModels.OfficialServers
{
    public class OfficialServersViewModel: BaseViewModel
    {
        public IEnumerable<OfficialServerObject> OfficialServers 
        {
            get => Get<IEnumerable<OfficialServerObject>>();
            set => Set(value);
        }

        public ICommand ShowServerInfoCommand => MakeCommand(ShowServerInfoCommandImplementation);
        public void ShowServerInfoCommandImplementation(object serverObject)
	    {
		    NavigateTo(Pages.ServerInfo, mode:NavigationMode.Master, navParams:
            new Dictionary<string, object>() {{
                "SelectedServer", serverObject
            }});
        }

        protected override async Task LoadDataAsync()
        {
			if (!IsConnected)
            {
                State = PageState.NoInternet;
                return;
            }

            var result = await DataServices.OfficialServersDataService.GetOfficialServers(CancellationToken);
            OfficialServers = result.Data;
        }
    }
}
