using ArkSE.DAL.DataObjects;
using Xamarin.Forms;

namespace ArkSE.UI.Pages.FavServers
{
	public partial class FavServersPage : BasePage<FavServersViewModel>
	{
		public FavServersPage ()
		{
			InitializeComponent ();
		}

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is OfficialGameServerObject gameServerObject)
                ViewModel.NavigateToGameServerInfo(gameServerObject);
        }
    }
}