using System;
using System.Net;
using SourceQuery;
using Xamarin.Forms;

namespace ArkSE
{
    public partial class ServerPage : ContentPage
    {
        private GameServer _server;
        private string _address;

        public GameServer Server
        {
            get => _server;
            set
            {
                _server = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                
                LoadServer();
                OnPropertyChanged();

            }
        }

        public ServerPage()
        {
            InitializeComponent();
        }

        private async void LoadServer()
        {
            try
            {
                var addressParts = Address.Split(':');

                Server = addressParts.Length == 1
                    ? new GameServer(IPAddress.Parse(Address))
                    : new GameServer(new IPEndPoint(IPAddress.Parse(addressParts[0]),
                        int.Parse(addressParts[1])));
            }
            catch (Exception e)
            {
                await DisplayAlert("Error", e.Message, "Ohh..");
                await Navigation.PopAsync();
            }
        }
    }
}