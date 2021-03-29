using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ArkSE.Helpers;
using Xamarin.Forms;

namespace ArkSE.BL.ViewModels
{
    public class BaseViewCell : Bindable, IDisposable
    {
        readonly CancellationTokenSource _networkTokenSource = new CancellationTokenSource();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~BaseViewCell()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            //ClearDialogs();
            CancelNetworkRequests();
        }
        public void CancelNetworkRequests()
        {
            _networkTokenSource.Cancel();
        }
    }
}
