using System.Collections.Generic;
using PlaceEveryItem.Configuration;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public class DataWallHalves
{
    public bool Enabled;
    public bool SprintKey;
    public int WallOffY;
}

public static class Patches
{
    private static readonly Cuboidf defaultSelectionBox = new(0, 0, 0, 1, 0.125f, 1);
    private static readonly Cuboidf defaultCollisionBox = new(0, 0, 0, 0, 0, 0);

    private static readonly GroundStorageProperties singleProps = new()
    {
        Layout = EnumGroundStorageLayout.SingleCenter,
        SelectionBox = defaultSelectionBox,
        CollisionBox = defaultCollisionBox
    };

    private static readonly GroundStorageProperties halvesProps = new()
    {
        Layout = EnumGroundStorageLayout.Halves,
        SelectionBox = defaultSelectionBox,
        CollisionBox = defaultCollisionBox
    };

    private static readonly GroundStorageProperties quadrantProps = new()
    {
        Layout = EnumGroundStorageLayout.Quadrants,
        SelectionBox = defaultSelectionBox,
        CollisionBox = defaultCollisionBox
    };

    private static readonly GroundStorageProperties blockStorageProps = new()
    {
        Layout = EnumGroundStorageLayout.Quadrants,
        SelectionBox = defaultSelectionBox,
        CollisionBox = defaultCollisionBox
    };

    private static GroundStorageProperties GetWallHalvesProps(KeyValuePair<string, DataWallHalves> val) => new()
    {
        Layout = EnumGroundStorageLayout.WallHalves,
        SprintKey = val.Value.SprintKey,
        WallOffY = val.Value.WallOffY,
        SelectionBox = defaultSelectionBox,
        CollisionBox = defaultCollisionBox
    };

    public static void AppendBehaviors(this ICoreAPI api, PlaceEveryItemConfig config)
    {
        for (int i = 0; i < api.World.Collectibles.Count; i++)
        {
            var obj = api.World.Collectibles[i];
            if (obj.Code == null) continue;
            if (obj.Id == 0) continue;
            if (obj.IsGroundStorable()) continue;

            foreach (var single in config.SingleCenter)
            {
                if (single.Key != null && single.Value && obj.WildcardRegexMatch(single.Key))
                {
                    obj.AppendBehavior(singleProps);
                    obj.ApplyCreativeInventoryTab();
                    break;
                }
            }
            foreach (var halve in config.Halves)
            {
                if (halve.Key != null && halve.Value && obj.WildcardRegexMatch(halve.Key))
                {
                    obj.AppendBehavior(halvesProps);
                    obj.ApplyCreativeInventoryTab();
                    break;
                }
            }
            foreach (var halve in config.WallHalves)
            {
                if (halve.Key != null && halve.Value?.Enabled == true && obj.WildcardRegexMatch(halve.Key))
                {
                    obj.AppendBehavior(GetWallHalvesProps(halve));
                    obj.ApplyCreativeInventoryTab();
                    break;
                }
            }
            foreach (var quadrant in config.Quadrants)
            {
                if (quadrant.Key != null && quadrant.Value && obj.WildcardRegexMatch(quadrant.Key))
                {
                    obj.AppendBehavior(quadrantProps);
                    obj.ApplyCreativeInventoryTab();
                    break;
                }
            }

            api.ApplyTransforms(obj);

            if (!config.AllBlocks) continue;

            obj.AppendBehavior(blockStorageProps);
            obj.ApplyCreativeInventoryTab();
            (obj as Block)?.ApplyBlockTransform();
        }
    }
}