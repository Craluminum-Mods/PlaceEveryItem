using System.Collections.Generic;
using System.Linq;
using PlaceEveryItem.Configuration;
using Vintagestory.API.Common;
using static Vintagestory.GameContent.EnumGroundStorageLayout;

namespace PlaceEveryItem;

public static class Patches
{
    public static void AppendBehaviors(this ICoreAPI api, PlaceEveryItemConfig config)
    {
        var compactProps = config
            .SingleCenter
            .ToDictionary(x => x.Key, x => new CompactProps { Layout = SingleCenter, Enabled = x.Value })
            .Concat(config.Halves.ToDictionary(x => x.Key, x => new CompactProps { Layout = Halves, Enabled = x.Value }))
            .Concat(config.Quadrants.ToDictionary(x => x.Key, x => new CompactProps { Layout = Quadrants, Enabled = x.Value }))
            .Concat(config.WallHalves.ToDictionary(x => x.Key, x => new CompactProps
            {
                Layout = WallHalves,
                Enabled = x.Value.Enabled,
                SprintKey = x.Value.SprintKey,
                WallOffY = x.Value.WallOffY
            }));

        foreach (var obj in api.World.Collectibles)
        {
            if (obj.Code == null || obj.Id == 0 || obj.IsGroundStorable())
                continue;

            if (config.AllBlocks && obj is Block block)
            {
                var gsprops = Quadrants.GetProps();
                gsprops.SprintKey = true;
                obj.AppendBehavior(gsprops);
                obj.ApplyCreativeInventoryTab();
                block.ApplyBlockTransform();
                continue;
            }

            foreach (var val in compactProps)
            {
                if (val.Value.Enabled && obj.IsMatched(val.Key))
                {
                    var gsprops = val.Value.GetProps();
                    gsprops.SprintKey = true;
                    obj.AppendBehavior(gsprops);
                    obj.ApplyCreativeInventoryTab();
                    obj.ApplyTransforms(api.ModLoader.GetModSystem<Core>().Transformations);
                    break;
                }
            }
        }
    }
}