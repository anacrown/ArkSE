using ArkSE.BL.ViewModels.ServerInfo;
using Xamarin.Forms;

namespace ArkSE.UI.Pages.ServerInfo
{
	public partial class ServerInfoPage : BasePage<ServerInfoViewModel>
	{
		public ServerInfoPage ()
		{
			InitializeComponent ();
		}

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            
        }
    }
}