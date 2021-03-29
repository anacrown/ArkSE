using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;
using ArkSE.DAL.DataObjects;

namespace ArkSE.DAL.DataServices.Online
{
    public class OfficialServersDataService : BaseOnlineDataService, IOfficialServersDataService
    {
        static readonly Regex OfficialServerLinePattern = new Regex(@"(\d+\.\d+\.\d+\.\d+)\s*//(\w*)");

        public Task<RequestResult<List<OfficialServerObject>>> GetOfficialServers(CancellationToken cts)
        {
            return GetOfficialServersAsync(cts);
        }

        private async Task<RequestResult<List<OfficialServerObject>>> GetOfficialServersAsync(CancellationToken cts)
        {
            try
            {
                var client = new RestClient("http://arkdedicated.com/officialservers.ini");
                var request = new RestRequest(Method.GET);

                var response = client.Execute(request);

                var servers = response.Content.Split(Environment.NewLine.ToCharArray())
                    .Where(line => !string.IsNullOrEmpty(line))
                    .Select(line => OfficialServerLinePattern.Match(line))
                    .Where(m => m.Success)
                    .Select(m => new OfficialServerObject()
                    {
                        Ip = m.Groups[1].Value,
                        Name = m.Groups[2].Value
                    });

                return new RequestResult<List<OfficialServerObject>>(servers.ToList(), RequestStatus.Ok);
            }
            catch (Exception e)
            {
                return new RequestResult<List<OfficialServerObject>>(null, RequestStatus.InternalServerError, e.Message);
            }
        }
    }
}
