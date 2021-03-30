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

        public new string Id => $"{Ip}:{Port}";
    }
}
