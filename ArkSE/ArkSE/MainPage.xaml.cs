using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using SourceQuery;
using Xamarin.Forms;

namespace ArkSE
{
    public partial class MainPage : ContentPage
    {
        private CancellationTokenSource throttleCts = new CancellationTokenSource();
        // public MainViewModel MainViewModel { get; }

        public MainPage()
        {
            // MainViewModel = mainViewModel;

            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is GameServer server)
                Navigation.PushModalAsync(new ServerPage {Server = server});
        }

        private async void InputView_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Interlocked.Exchange(ref this.throttleCts, new CancellationTokenSource()).Cancel();
            await Task.Delay(TimeSpan.FromMilliseconds(500), this.throttleCts.Token)
                .ContinueWith(async task => await Refresh(e.NewTextValue),
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnRanToCompletion,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async Task Refresh(string text)
        {
            // foreach (var officialServer in MainViewModel.OfficialServers)
            // {
            //     officialServer.Visible = officialServer.Name.Contains(text);
            // }
        }
    }
}
