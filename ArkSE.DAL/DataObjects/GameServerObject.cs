using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSE.DAL.DataObjects
{
    public class GameServerObject : BaseDataObject
    {
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
    }
}
