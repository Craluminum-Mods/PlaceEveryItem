using PlaceEveryItem.Configuration;
using Vintagestory.API.Common;
using static Vintagestory.GameContent.EnumGroundStorageLayout;

namespace PlaceEveryItem;

public class DataWallHalves
{
    public bool Enabled;
    public bool SprintKey;
    public int WallOffY;
}

public static class Patches
{
    public static void AppendBehaviors(this ICoreAPI api, PlaceEveryItemConfig config)
    {
        var transformations = api.ModLoader.GetModSystem<Core>().transformations;

        foreach (var obj in api.World.Collectibles)
        {
            if (obj.Code == null || obj.Id == 0 || obj.IsGroundStorable())
                continue;

            if (config.AllBlocks && obj is Block block)
            {
                obj.AppendBehavior(Quadrants.GetProps());
                obj.ApplyCreativeInventoryTab();
                block.ApplyBlockTransform();
                continue;
            }

            bool matched = false;

            foreach (var single in config.SingleCenter)
            {
                if (single.Value && obj.IsMatched(single.Key))
                {
                    obj.AppendBehavior(SingleCenter.GetProps());
                    matched = true;
                    break;
                }
            }

            if (matched)
            {
                obj.ApplyCreativeInventoryTab();
                obj.ApplyTransforms(transformations);
                continue;
            }

            foreach (var halve in config.Halves)
            {
                if (halve.Value && obj.IsMatched(halve.Key))
                {
                    obj.AppendBehavior(Halves.GetProps());
                    matched = true;
                    break;
                }
            }

            if (matched)
            {
                obj.ApplyCreativeInventoryTab();
                obj.ApplyTransforms(transformations);
                continue;
            }

            foreach (var wallHalve in config.WallHalves)
            {
                if (wallHalve.Value?.Enabled == true && obj.IsMatched(wallHalve.Key))
                {
                    obj.AppendBehavior(WallHalves.GetProps(wallHalve.Value));
                    matched = true;
                    break;
                }
            }

            if (matched)
            {
                obj.ApplyCreativeInventoryTab();
                obj.ApplyTransforms(transformations);
                continue;
            }

            foreach (var quadrant in config.Quadrants)
            {
                if (quadrant.Value && obj.IsMatched(quadrant.Key))
                {
                    obj.AppendBehavior(Quadrants.GetProps());
                    matched = true;
                    break;
                }
            }

            if (matched)
            {
                obj.ApplyCreativeInventoryTab();
                obj.ApplyTransforms(transformations);
                continue;
            }
        }
    }
}