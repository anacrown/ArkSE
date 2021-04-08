using System;
using ArkSE.DAL.SourceQuery;

namespace ArkSE.DAL.DataObjects
{
    public class OfficialPlayerObject : BaseDataObject
    {
        public byte Index { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public TimeSpan TimeConnected { get; set; }
    }

    public static class PlayerInfoExtention
    {
        public static OfficialPlayerObject GetPlayerObject(this PlayerInfo playerInfo)
        {
            return new OfficialPlayerObject
            {
                Name = playerInfo.Name,
                Index = playerInfo.Index,
                Score = playerInfo.Score,
                TimeConnected = playerInfo.TimeConnected
            };
        }
    }
}