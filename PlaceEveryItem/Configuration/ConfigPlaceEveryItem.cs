using Newtonsoft.Json;
using System.Collections.Generic;
using Vintagestory.API.Common;
using Vintagestory.API.Util;

namespace PlaceEveryItem.Configuration;

public class ConfigPlaceEveryItem : IModConfig
{
    [JsonProperty(Order = 1)]
    public bool AutoFill { get; set; } = true;

    [JsonProperty(Order = 2)]
    public GroundStorables Items { get; set; } = new();

    [JsonProperty(Order = 3)]
    public GroundStorables Blocks { get; set; } = new();

    [JsonProperty(Order = 2)]
    public List<string> BlacklistItems { get; set; } = new();

    [JsonProperty(Order = 3)]
    public List<string> BlacklistBlocks { get; set; } = new();

    public ConfigPlaceEveryItem(ICoreAPI api, ConfigPlaceEveryItem previousConfig = null)
    {
        if (previousConfig != null)
        {
            AutoFill = previousConfig.AutoFill;

            Items.SingleCenter.AddRange(previousConfig.Items.SingleCenter);
            Items.Halves.AddRange(previousConfig.Items.Halves);
            Items.WallHalves.AddRange(previousConfig.Items.WallHalves);
            Items.Quadrants.AddRange(previousConfig.Items.Quadrants);

            Blocks.SingleCenter.AddRange(previousConfig.Blocks.SingleCenter);
            Blocks.Halves.AddRange(previousConfig.Blocks.Halves);
            Blocks.WallHalves.AddRange(previousConfig.Blocks.WallHalves);
            Blocks.Quadrants.AddRange(previousConfig.Blocks.Quadrants);

            BlacklistItems.AddRange(previousConfig.BlacklistItems);
            BlacklistBlocks.AddRange(previousConfig.BlacklistBlocks);
        }

        if (api != null && AutoFill)
        {
            FillDefault(api);
        }
    }

    public void FillDefault(ICoreAPI api)
    {
        Core core = Core.GetInstance(api);

        Items.SingleCenter.AddRange(core.DefaultGroundStorableItems.SingleCenter);
        Items.Halves.AddRange(core.DefaultGroundStorableItems.Halves);
        Items.WallHalves.AddRange(core.DefaultGroundStorableItems.WallHalves);
        Items.Quadrants.AddRange(core.DefaultGroundStorableItems.Quadrants);

        Blocks.SingleCenter.AddRange(core.DefaultGroundStorableBlocks.SingleCenter);
        Blocks.Halves.AddRange(core.DefaultGroundStorableBlocks.Halves);
        Blocks.WallHalves.AddRange(core.DefaultGroundStorableBlocks.WallHalves);
        Blocks.Quadrants.AddRange(core.DefaultGroundStorableBlocks.Quadrants);

        BlacklistItems.AddRange(core.DefaultBlacklistItems);
        BlacklistBlocks.AddRange(core.DefaultBlacklistBlocks);
    }
}