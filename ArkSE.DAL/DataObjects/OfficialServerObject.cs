﻿namespace ArkSE.DAL.DataObjects
{
    public class OfficialServerObject : BaseDataObject
    {
        public string Ip { get; set; }
        public string Name { get; set; }

        public new string Id => Ip;
    }
}
