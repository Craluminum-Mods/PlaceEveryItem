using System.Collections.Generic;
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

    public static void AppendBehaviors(
        this ICoreAPI api,
        bool AllBlocks,
        Dictionary<string, bool> singleCenter,
        Dictionary<string, bool> halves,
        Dictionary<string, DataWallHalves> wallHalves,
        Dictionary<string, bool> quadrants)
    {
        foreach (var obj in api.World.Collectibles)
        {
            if (obj.Code == null) continue;
            if (obj.Id == 0) continue;
            if (obj.IsGroundStorable()) continue;

            foreach (var single in singleCenter)
            {
                if (single.Key != null && single.Value && obj.WildcardRegexMatch(single.Key) && !obj.IsGroundStorable())
                {
                    var singleProps = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.SingleCenter,
                        SelectionBox = defaultSelectionBox,
                        CollisionBox = defaultCollisionBox
                    };

                    obj.AppendBehavior(singleProps);
                    obj.ApplyCreativeInventoryTab();
                }
            }
            foreach (var halve in halves)
            {
                if (halve.Key != null && halve.Value && obj.WildcardRegexMatch(halve.Key) && !obj.IsGroundStorable())
                {
                    var halvesProps = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Halves,
                        SelectionBox = defaultSelectionBox,
                        CollisionBox = defaultCollisionBox
                    };

                    obj.AppendBehavior(halvesProps);
                    obj.ApplyCreativeInventoryTab();
                }
            }
            foreach (var halve in wallHalves)
            {
                if (halve.Key != null && halve.Value?.Enabled == true && obj.WildcardRegexMatch(halve.Key) && !obj.IsGroundStorable())
                {
                    var wallHalvesProps = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.WallHalves,
                        SprintKey = halve.Value.SprintKey,
                        WallOffY = halve.Value.WallOffY,
                        SelectionBox = defaultSelectionBox,
                        CollisionBox = defaultCollisionBox
                    };

                    obj.AppendBehavior(wallHalvesProps);
                    obj.ApplyCreativeInventoryTab();
                }
            }
            foreach (var quadrant in quadrants)
            {
                if (quadrant.Key != null && quadrant.Value && obj.WildcardRegexMatch(quadrant.Key) && !obj.IsGroundStorable())
                {
                    var quadrantProps = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Quadrants,
                        SelectionBox = defaultSelectionBox,
                        CollisionBox = defaultCollisionBox
                    };

                    obj.AppendBehavior(quadrantProps);
                    obj.ApplyCreativeInventoryTab();
                }
            }

            api.ApplyTransforms(obj);
        }

        if (AllBlocks)
        {
            foreach (var block in api.World.Blocks)
            {
                if (block.Code == null) continue;
                if (block.Id == 0) continue;

                if (!block.IsGroundStorable())
                {
                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Quadrants,
                        SelectionBox = defaultSelectionBox,
                        CollisionBox = defaultCollisionBox
                    };

                    block.AppendBehavior(gsprops);
                    block.ApplyCreativeInventoryTab();
                    block.ApplyBlockTransform();
                }
            }
        }
    }
}