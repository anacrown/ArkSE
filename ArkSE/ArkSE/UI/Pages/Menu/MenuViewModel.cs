using System.Windows.Input;
using ArkSE.DAL.DataObjects;
using ArkSE.DAL.SourceQuery;
using ArkSE.Helpers;

namespace ArkSE.UI.Pages.Menu
{
    public class MenuViewModel: BaseViewModel {
	    public ICommand GoToLoginCommand => MakeMenuCommand(ArkSE.Pages.Login);
	    public ICommand GoToFavServersCommand => MakeMenuCommand(ArkSE.Pages.FavServers);
	    public ICommand GoToOfficialServersCommand => MakeMenuCommand(ArkSE.Pages.DedicatedServersList);
		public ICommand AddServerToFavorite => MakeCommand(AddServerToFavoriteImplementation);

        private static void AddServerToFavoriteImplementation()
        {
            SettingService.FavServers.Add(GameServer.Create("46.251.238.159:27017").GetServerObject());
        }

        // public List<RestaurantsObject> RestaurantItemsSource
	    // {
		   //  get => Get<List<RestaurantsObject>>();
		   //  set => Set(value);
	    // }
		static ICommand MakeMenuCommand(object page) {
			return MakeNavigateToCommand(page, NavigationMode.Master, newNavigationStack: true, withAnimation: false);
		}

        // protected override async Task LoadDataAsync()
		// {
		// 	var response = await DataServices.Restaurant.GetAllRestaurants(SettingService.HotelId, CancellationToken);
		// 	if (response.IsValid)
		// 		RestaurantItemsSource = response.Data;
		// }
    }
}
