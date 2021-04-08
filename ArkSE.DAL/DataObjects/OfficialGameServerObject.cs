using System.Linq;
using ArkSE.DAL.SourceQuery;

namespace ArkSE.DAL.DataObjects
{
    public class OfficialGameServerObject : BaseDataObject
    {
        public string Ip { get; set; }
        public short Port { get; set; }
        public short SpectatorPort { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public byte PlayerCount { get; set; }
        public byte MaximumPlayerCount { get; set; }
        public string ServerType { get; set; }
        public string OS { get; set; }
        public bool RequiresPassword { get; set; }
        public bool VACSecured { get; set; }
        public string GameVersion { get; set; }
        public string SteamId { get; set; }
        public OfficialPlayerObject[] Players { get; set; }

        public new string Id => $"{Ip}:{Port}";
    }

    public static class GameServerExtention
    {
        public static OfficialGameServerObject GetServerObject(this GameServer gameServer)
        {
            return new OfficialGameServerObject()
            {
                Ip = gameServer.Endpoint,
                Port = gameServer.Port,
                Name = gameServer.Name,
                Map = gameServer.Map,
                PlayerCount = gameServer.PlayerCount,
                MaximumPlayerCount = gameServer.MaximumPlayerCount,
                GameVersion = gameServer.GameVersion,
                RequiresPassword = gameServer.RequiresPassword,
                OS = gameServer.OS.ToString(),
                ServerType = gameServer.ServerType.ToString(),
                SpectatorPort = gameServer.SpectatorPort,
                SteamId = gameServer.SteamId,
                VACSecured = gameServer.VACSecured,
                Players = gameServer.Players.Select(p => p.GetPlayerObject()).ToArray()
            };
        }
    }
}
