using ArkSE.BL.ViewModels.OfficialServers;
using ArkSE.DAL.DataObjects;
using Xamarin.Forms;

namespace ArkSE.UI.Pages.OfficialServers
{
	public partial class OfficialServersPage : BasePage<OfficialServersViewModel>
	{
		public OfficialServersPage ()
		{
			InitializeComponent ();
		}

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is OfficialServerObject serverObject)
                ViewModel.ShowServerInfoCommandImplementation(serverObject);
        }
    }
}