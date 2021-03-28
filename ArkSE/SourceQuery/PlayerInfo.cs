using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SourceQuery
{
    [Serializable]
    public class PlayerInfo
    {
        public byte Index;
        public string Name;
        public int Score;
        public TimeSpan TimeConnected;

        public static PlayerInfo FromBinaryReader(BinaryReader br)
        {
            var playerInfo = new PlayerInfo
            {
                Index = br.ReadByte(),
                Name = br.ReadAnsiString(),
                Score = br.ReadInt32(),
                TimeConnected = TimeSpan.FromSeconds(br.ReadSingle())
            };
            return playerInfo;
        }

        public override string ToString() => $"{Index}\t{TimeConnected}\t{Name}";
    }
}
