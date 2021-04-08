using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;
using ArkSE.DAL.DataObjects;
using ArkSE.DAL.SourceQuery;

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

        public Task<RequestResult<List<OfficialGameServerObject>>> GetOfficialGameServerObjects(
            OfficialServerObject serverObject, CancellationToken cts)
        {
            return GetOfficialGameServerObjectsAsync(serverObject, cts);
        }

        private async Task<RequestResult<List<OfficialGameServerObject>>> GetOfficialGameServerObjectsAsync(
            OfficialServerObject serverObject, CancellationToken cts)
        {
            try
            {
                var gameServerObjects = new List<OfficialGameServerObject>();
                foreach (var port in Ports)
                {
                    if (cts.IsCancellationRequested)
                        return new RequestResult<List<OfficialGameServerObject>>(null, RequestStatus.Canceled);

                    if (TryCreateServer(serverObject.Ip, port, out var gameServer))
                        gameServerObjects.Add(gameServer.GetServerObject());
                }

                return new RequestResult<List<OfficialGameServerObject>>(gameServerObjects, RequestStatus.Ok);
            }
            catch (Exception e)
            {
                return new RequestResult<List<OfficialGameServerObject>>(null, RequestStatus.InternalServerError, e.Message);
            }
        }

        private static readonly int[] Ports = { 27015, 27017, 27019, 27021 };

        private bool TryCreateServer(string ip, int port, out GameServer gameServer)
        {
            try
            {
                gameServer = new GameServer(new IPEndPoint(IPAddress.Parse(ip), port));
                return true;
            }
            catch (Exception)
            {
                gameServer = null;
                return false;
            }
        }
    }
}
