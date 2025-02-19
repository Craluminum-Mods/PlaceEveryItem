using System.Collections.Generic;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public class GroundStorables
{
    public Dictionary<string, bool> SingleCenter { get; set; } = new();
    public Dictionary<string, bool> Halves { get; set; } = new();
    public Dictionary<string, DataWallHalves> WallHalves { get; set; } = new();
    public Dictionary<string, bool> Quadrants { get; set; } = new();

    public Dictionary<string, GroundStorageProperties> GetPropsFromAll()
    {
        Dictionary<string, GroundStorageProperties> dict = new Dictionary<string, GroundStorageProperties>();

        foreach (KeyValuePair<string, bool> elem in SingleCenter)
        {
            GroundStorageProperties props = new()
            {
                Layout = EnumGroundStorageLayout.SingleCenter,
                SelectionBox = new(0, 0, 0, 1, 0.125f, 1),
                CollisionBox = new(0, 0, 0, 0, 0, 0)
            };
            dict.Add(elem.Key, props);
        }

        foreach (KeyValuePair<string, bool> elem in Halves)
        {
            GroundStorageProperties props = new()
            {
                Layout = EnumGroundStorageLayout.Halves,
                SelectionBox = new(0, 0, 0, 1, 0.125f, 1),
                CollisionBox = new(0, 0, 0, 0, 0, 0)
            };
            dict.Add(elem.Key, props);
        }

        foreach (KeyValuePair<string, DataWallHalves> elem in WallHalves)
        {
            GroundStorageProperties props = new()
            {
                Layout = EnumGroundStorageLayout.WallHalves,
                SprintKey = elem.Value.SprintKey,
                WallOffY = elem.Value.WallOffY,
                SelectionBox = new(0, 0, 0, 1, 0.125f, 1),
                CollisionBox = new(0, 0, 0, 0, 0, 0)
            };
            dict.Add(elem.Key, props);
        }

        foreach (KeyValuePair<string, bool> elem in Quadrants)
        {
            GroundStorageProperties props = new()
            {
                Layout = EnumGroundStorageLayout.Quadrants,
                SelectionBox = new(0, 0, 0, 1, 0.125f, 1),
                CollisionBox = new(0, 0, 0, 0, 0, 0)
            };
            dict.Add(elem.Key, props);
        }

        return dict;
    }
}