using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ArkSE.DAL.DataObjects;
using ArkSE.DAL.DataServices;
using ArkSE.Helpers;

namespace ArkSE.BL.ViewModels.OfficialServers
{
    public class OfficialServersViewModel : BaseViewModel
    {
        public IEnumerable<OfficialServerObject> OfficialServers
        {
            get => Get<IEnumerable<OfficialServerObject>>();
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

            ShowLoading();
            var result = await DataServices.OfficialServersDataService.GetOfficialServers(CancellationToken);

            OfficialServers = result.Data;
            HideLoading();
        }
    }

    public class OfficialServerInfo : Bindable
    {
        public OfficialServerObject ServerObject { get; }

        public string Status
        {
            get => Get<string>();
            set => Set(value);
        }

        public OfficialServerInfo(OfficialServerObject serverObject, bool runPing = false)
        {
            ServerObject = serverObject;

            if (runPing) 
                PingRunAsync();
        }

        public void PingRunAsync()
        {
            Task.Run(Ping);
        }

        private static string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        private static byte[] buffer = Encoding.ASCII.GetBytes(data);
        private static int timeout = 120;

        public void Ping()
        {
            var pingSender = new Ping();
            var options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            var reply = pingSender.Send(ServerObject.Ip, timeout, buffer, options);

            if (reply == null)
            {
                Status = "server error";
                return;
            }

            if (reply.Status == IPStatus.Success)
            {
                Status = $"ping {reply.RoundtripTime}ms";
            }
            else
            {
                Status = reply.Status.ToString();
            }
        }
    }
}
