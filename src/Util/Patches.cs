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
        foreach (var obj in api.World.Collectibles)
        {
            bool matchedSingle = false;
            bool matchedHalves = false;
            bool matchedWallHalves = false;
            bool matchedQuadrants = false;

            if (obj.Code == null || obj.Id == 0 || obj.IsGroundStorable())
                continue;

            foreach (var single in config.SingleCenter)
            {
                if (single.Value && obj.IsMatched(single.Key))
                {
                    obj.AppendBehavior(singleProps);
                    obj.ApplyCreativeInventoryTab();
                    api.ApplyTransforms(obj);
                    matchedSingle = true;
                    break;
                }
            }

            if (matchedSingle) continue;

            foreach (var halve in config.Halves)
            {
                if (halve.Value && obj.IsMatched(halve.Key))
                {
                    obj.AppendBehavior(halvesProps);
                    obj.ApplyCreativeInventoryTab();
                    api.ApplyTransforms(obj);
                    matchedHalves = true;
                    break;
                }
            }

            if (matchedHalves) continue;

            foreach (var halve in config.WallHalves)
            {
                if (halve.Value?.Enabled == true && obj.IsMatched(halve.Key))
                {
                    obj.AppendBehavior(GetWallHalvesProps(halve));
                    obj.ApplyCreativeInventoryTab();
                    api.ApplyTransforms(obj);
                    matchedWallHalves = true;
                    break;
                }
            }

            if (matchedWallHalves) continue;

            foreach (var quadrant in config.Quadrants)
            {
                if (quadrant.Value && obj.IsMatched(quadrant.Key))
                {
                    obj.AppendBehavior(quadrantProps);
                    obj.ApplyCreativeInventoryTab();
                    api.ApplyTransforms(obj);
                    matchedQuadrants = true;
                    break;
                }
            }

            if (matchedQuadrants) continue;

            if (!config.AllBlocks || obj is not Block block) continue;

            obj.AppendBehavior(blockStorageProps);
            obj.ApplyCreativeInventoryTab();
            block.ApplyBlockTransform();
        }
    }
}