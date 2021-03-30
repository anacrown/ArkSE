using ArkSE.DAL.DataServices.Online;

namespace ArkSE.DAL.DataServices {
	public static class DataServices {
		public static void Init(bool isMock) {
			if (isMock) {
				// Services = new Mock.ServicesDataService();
				// Profile = new Mock.ProfileDataService();
				// Fitness = new Mock.FitnessDataService();
				// Restaurant = new Mock.RestaurantDataService();
				// Guide = new Mock.GuideDataService();
				// Chat = new Mock.ChatDataService();
				// Hotel = new Mock.HotelDataService();
			}
			else {
				OfficialServersDataService = new OfficialServersDataService();
			}
		}

		public static IOfficialServersDataService OfficialServersDataService { get; private set; }
		// public static IProfileDataService Profile { get; private set; }
		// public static IFitnessDataService Fitness { get; private set; }
		// public static IRestaurantDataService Restaurant { get; private set; }
		// public static IGuideDataService Guide { get; private set; }
		// public static IHotelDataService Hotel { get; private set; }
		// public static IChatDataService Chat { get; private set; }
	}
}
