using ArkSE.DAL.DataObjects;
using ArkSE.UI.Pages.DedicatedServerInfo;
using Xamarin.Forms;

namespace ArkSE.UI.Pages.DedicatedServersList
{
	public partial class DedicatedServersListPage : BasePage<DedicatedServersListViewModel>
	{
		public DedicatedServersListPage ()
		{
			InitializeComponent ();
		}

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is OfficialServerObject serverObject)
                ViewModel.NavigateToDedicatedServersList(serverObject);
        }
    }
}