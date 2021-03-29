using System;
using System.Threading.Tasks;

namespace ArkSE.DAL.DataServices.Online
{
    public class BaseOnlineDataService
    {
        protected async Task<RequestResult<T>> GetOnlineData<T>(Func<T> getData) where T : class
        {
            try
            {
                var data = getData();
                return new RequestResult<T>(data, RequestStatus.Ok);
            }
            catch (Exception e)
            {
                return new RequestResult<T>(default(T), RequestStatus.InternalServerError, e.Message);
            }
        }
    }
}
