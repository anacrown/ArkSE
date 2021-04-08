using ArkSE.DAL.DataObjects;
using ArkSE.DAL.DataServices;
using ArkSE.DAL.SourceQuery;
using ArkSE.Helpers;
using ArkSE.UI;
using Xamarin.Forms;

namespace ArkSE
{
    public partial class App : Application
    {
        // public MainViewModel MainViewModel { get; set; } = new MainViewModel();

        public App()
        {
            InitializeComponent();

            Current.MainPage = new ContentPage();
        }

        protected override async void OnStart()
        {
            SettingService.Init(this);
            DialogService.Init(this);
            DataServices.Init(false);
            await NavigationService.Init(Pages.Login);
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {
            
        }
    }

    // public class MainViewModel
    // {
    //     public ObservableCollection<GameServer> OfficialServers { get; set; } = new ObservableCollection<GameServer>();
    //
    //     private static readonly int[] Ports = { 27015, 27017, 27019, 27021 };
    //
    //     private GameServer CreateServer(string ip, int port)
    //     {
    //         try
    //         {
    //             return new GameServer(new IPEndPoint(IPAddress.Parse(ip), port));
    //         }
    //         catch (Exception)
    //         {
    //             return null;
    //         }
    //     }
    //
    //     private IEnumerable<GameServer> GetServers(string ip) => Ports.Select(port => CreateServer(ip, port)).Where(gs => gs != null);
    //
    //     public void LoadOfficialServers()
    //     {
    //         OfficialServers.Clear();
    //
    //         var client = new RestClient("http://arkdedicated.com/officialservers.ini");
    //         var request = new RestRequest(Method.GET);
    //
    //         var servers = new Dictionary<EndPoint, (int reqCount, double score)>();
    //
    //         IRestResponse response = client.Execute(request);
    //
    //         var lines = response.Content.Split(Environment.NewLine.ToCharArray())
    //             .Where(l => !string.IsNullOrEmpty(l))
    //             .Select(l => l.Trim())
    //             .ToArray();
    //
    //
    //
    //         Parallel.ForEach(lines, line =>
    //         {
    //             var linePart = line.Split("//".ToCharArray())
    //                 .Where(l => !string.IsNullOrEmpty(l))
    //                 .Select(l => l.Trim())
    //                 .ToArray();
    //
    //             var dedicIp = linePart[0];
    //             var dedicName = linePart[1];
    //
    //             foreach (var gameServer in GetServers(dedicIp))
    //                 OfficialServers.Add(gameServer);
    //         });
    //     }
    // }
}
