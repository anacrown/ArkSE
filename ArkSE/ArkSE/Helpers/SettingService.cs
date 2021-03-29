using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ArkSE.DAL.DataObjects;
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

			FavServers ??= new ObservableCollection<OfficialServerObject>();

            FavServers.CollectionChanged += (sender, args) =>
                Set(FavServers, nameof(FavServers));
        }

		public static ObservableCollection<OfficialServerObject> FavServers
		{
			get => Get<ObservableCollection<OfficialServerObject>>();
			set => Set(value);
		}

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
