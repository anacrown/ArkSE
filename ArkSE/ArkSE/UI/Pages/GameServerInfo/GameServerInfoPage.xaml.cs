using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArkSE.UI.Pages.GameServerInfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameServerInfoPage : BasePage<GameServerInfoViewModel>
    {
        public GameServerInfoPage()
        {
            InitializeComponent();
        }
    }
}