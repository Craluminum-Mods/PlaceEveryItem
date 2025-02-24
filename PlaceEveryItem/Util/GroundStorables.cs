using System.Collections.Generic;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public class GroundStorables
{
    public Dictionary<string, DataGroundStorable> SingleCenter { get; set; } = new();
    public Dictionary<string, DataGroundStorable> Halves { get; set; } = new();
    public Dictionary<string, DataWallHalves> WallHalves { get; set; } = new();
    public Dictionary<string, DataGroundStorable> Quadrants { get; set; } = new();

    public Dictionary<string, GroundStoragePropertiesExtended> GetPropsFromAll()
    {
        Dictionary<string, GroundStoragePropertiesExtended> dict = new Dictionary<string, GroundStoragePropertiesExtended>();

        foreach (KeyValuePair<string, DataGroundStorable> elem in SingleCenter)
        {
            if (elem.Value.Enabled)
            {
                dict.Add(elem.Key, elem.Value.GetProps(EnumGroundStorageLayout.SingleCenter).Clone());
            }
        }

        foreach (KeyValuePair<string, DataGroundStorable> elem in Halves)
        {
            if (elem.Value.Enabled)
            {
                dict.Add(elem.Key, elem.Value.GetProps(EnumGroundStorageLayout.Halves).Clone());
            }
        }

        foreach (KeyValuePair<string, DataWallHalves> elem in WallHalves)
        {
            if (elem.Value.Enabled)
            {
                dict.Add(elem.Key, elem.Value.GetProps(EnumGroundStorageLayout.WallHalves).Clone());
            }
        }

        foreach (KeyValuePair<string, DataGroundStorable> elem in Quadrants)
        {
            if (elem.Value.Enabled)
            {
                dict.Add(elem.Key, elem.Value.GetProps(EnumGroundStorageLayout.Quadrants).Clone());
            }
        }

        return dict;
    }
}