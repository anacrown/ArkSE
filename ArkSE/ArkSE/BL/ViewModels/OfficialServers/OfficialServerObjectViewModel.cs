using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ArkSE.DAL.DataObjects;

namespace ArkSE.BL.ViewModels.OfficialServers
{
    public class OfficialServerObjectViewModel : BaseViewModel
    {
        public OfficialServerObject ServerObject
        {
            get => Get<OfficialServerObject>();
            set => Set(value);
        }

        public OfficialServerObjectViewModel(OfficialServerObject serverObject)
        {
            ServerObject = serverObject;
        }

        protected override Task LoadDataAsync()
        {
            return base.LoadDataAsync();
        }
    }
}
