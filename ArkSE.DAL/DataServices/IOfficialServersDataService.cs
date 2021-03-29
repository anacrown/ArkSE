using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArkSE.DAL.DataObjects;

namespace ArkSE.DAL.DataServices
{
    public interface  IOfficialServersDataService
    {
        Task<RequestResult<List<OfficialServerObject>>> GetOfficialServers(CancellationToken cts);
    }
}
