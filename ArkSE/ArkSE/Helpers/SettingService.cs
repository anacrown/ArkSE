using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ArkSE.DAL.DataObjects;
using ArkSE.DAL.SourceQuery;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ArkSE.Helpers
{
	public static class SettingService
	{
		static readonly object Locker = new object();
		static Func<IDictionary<string, object>> _settingsFunc;
		static Func<Task> _saveFunc;
		static IDictionary<string, object> Settings => _settingsFunc?.Invoke();

		public static void Init(Application app)
		{
			_settingsFunc = ()=> app.Properties;
			_saveFunc = app.SavePropertiesAsync;

            if (Preferences.ContainsKey(nameof(Addreses)))
                Addreses = Preferences.Get(nameof(Addreses), null)?.Split(';').ToList();

			Addreses ??= new List<string>();

            FavServers = new ObservableCollection<OfficialGameServerObject>(Addreses.Select(address => GameServer.Create(address).GetServerObject()));

            FavServers.CollectionChanged += (sender, args) =>
            {
                Addreses = FavServers.Select(gs => $"{gs.Ip}:{gs.Port}").ToList();
				Preferences.Set(nameof(Addreses), string.Join(";", Addreses));
                Set(FavServers, nameof(FavServers));
            };
        }

		public static ObservableCollection<OfficialGameServerObject> FavServers
		{
			get => Get<ObservableCollection<OfficialGameServerObject>>();
			set => Set(value);
		}

        private static List<string> Addreses;

		#region Internal

		static T Get<T>([CallerMemberNameAttribute] string key = null)
		{
			lock (Locker)
			{
				var settings = Settings;
                if (settings.TryGetValue(key, out var value))
					if (value is T typedValue) return typedValue;

				return default;
			}

		}

		static void Set<T>(T value,[CallerMemberNameAttribute] string key = null)
		{
			lock (Locker)
			{
				var settings = Settings;
				if (settings.ContainsKey(key))
					Settings[key] = value;
				else
					settings.Add(key, value);
			}

			Task.Run(()=>_saveFunc?.Invoke());
		}

        #endregion



	}
}
