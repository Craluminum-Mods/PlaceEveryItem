using System.Collections.Generic;
using Vintagestory.API.Server;
using System.Linq;

namespace PlaceEveryItem.Configuration
{
    public class PlaceEveryItemConfig
    {
        public bool AllBlocks = true;
        public Dictionary<string, bool> Halves { get; set; } = new();
        public Dictionary<string, bool> Quadrants { get; set; } = new();
        public Dictionary<string, bool> SingleCenter { get; set; } = new();
        public Dictionary<string, DataWallHalves> WallHalves { get; set; } = new();

        public PlaceEveryItemConfig() { }

        public PlaceEveryItemConfig(ICoreServerAPI sapi)
        {
            var modSys = sapi.ModLoader.GetModSystem<Core>();

            foreach (var keyVal in modSys.DefaultHalves.Where(keyVal => !Halves.ContainsKey(keyVal.Key)))
            {
                Halves.Add(keyVal.Key, keyVal.Value);
            }

            foreach (var keyVal in modSys.DefaultQuadrants.Where(keyVal => !Quadrants.ContainsKey(keyVal.Key)))
            {
                Quadrants.Add(keyVal.Key, keyVal.Value);
            }

            foreach (var keyVal in modSys.DefaultSingleCenter.Where(keyVal => !SingleCenter.ContainsKey(keyVal.Key)))
            {
                SingleCenter.Add(keyVal.Key, keyVal.Value);
            }

            foreach (var keyVal in modSys.DefaultWallHalves.Where(keyVal => !WallHalves.ContainsKey(keyVal.Key)))
            {
                WallHalves.Add(keyVal.Key, keyVal.Value);
            }
        }

        public PlaceEveryItemConfig(PlaceEveryItemConfig previousConfig)
        {
            AllBlocks = previousConfig.AllBlocks;

            foreach (var keyVal in previousConfig.SingleCenter.Where(keyVal => !SingleCenter.ContainsKey(keyVal.Key)))
            {
                SingleCenter.Add(keyVal.Key, keyVal.Value);
            }

            foreach (var keyVal in previousConfig.Halves.Where(keyVal => !Halves.ContainsKey(keyVal.Key)))
            {
                Halves.Add(keyVal.Key, keyVal.Value);
            }

            foreach (var keyVal in previousConfig.WallHalves.Where(keyVal => !WallHalves.ContainsKey(keyVal.Key)))
            {
                WallHalves.Add(keyVal.Key, keyVal.Value);
            }

            foreach (var keyVal in previousConfig.Quadrants.Where(keyVal => !Quadrants.ContainsKey(keyVal.Key)))
            {
                Quadrants.Add(keyVal.Key, keyVal.Value);
            }
        }
    }
}