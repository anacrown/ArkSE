using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ArkSE.DAL.DataServices;
using ArkSE.Helpers;

namespace ArkSE.BL.ViewModels.Menu
{
    public class MenuViewModel: BaseViewModel {
	    public ICommand GoToLoginCommand => MakeMenuCommand(Pages.Login);
	    public ICommand GoToFavServersCommand => MakeMenuCommand(Pages.FavServers);
	    public ICommand GoToOfficialServersCommand => MakeMenuCommand(Pages.OfficialServers);

	    // public List<RestaurantsObject> RestaurantItemsSource
	    // {
		   //  get => Get<List<RestaurantsObject>>();
		   //  set => Set(value);
	    // }
		static ICommand MakeMenuCommand(object page) {
			return MakeNavigateToCommand(page, NavigationMode.RootPage, newNavigationStack: true, withAnimation: false);
		}

		// protected override async Task LoadDataAsync()
		// {
		// 	var response = await DataServices.Restaurant.GetAllRestaurants(SettingService.HotelId, CancellationToken);
		// 	if (response.IsValid)
		// 		RestaurantItemsSource = response.Data;
		// }
    }
}
