using ArkSE.DAL.DataObjects;
using ArkSE.UI.Pages.DedicatedServersList;
using Xamarin.Forms;

namespace ArkSE.UI.Pages.DedicatedServerInfo
{
	public partial class DedicatedServerInfoPage : BasePage<DedicatedServerInfoViewModel>
	{
		public DedicatedServerInfoPage ()
		{
			InitializeComponent ();
		}

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is OfficialGameServerObject gameServerObject)
                ViewModel.NavigateToDedicatedServerInfo(gameServerObject);
        }
    }
}