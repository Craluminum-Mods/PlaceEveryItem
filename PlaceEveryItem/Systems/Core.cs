using PlaceEveryItem.Configuration;
using System.Collections.Generic;
using System.Linq;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public class Core : ModSystem
{
    public ConfigPlaceEveryItem Config { get; private set; }

    public Dictionary<string, ModelTransform> ItemTransformations { get; private set; } = new();
    public Dictionary<string, ModelTransform> BlockTransformations { get; private set; } = new();

    public List<string> DefaultBlacklistItems { get; private set; } = new();
    public List<string> DefaultBlacklistBlocks { get; private set; } = new();

    public GroundStorables DefaultGroundStorableItems { get; private set; } = new();
    public GroundStorables DefaultGroundStorableBlocks { get; private set; } = new();

    public static Core GetInstance(ICoreAPI api) => api.ModLoader.GetModSystem<Core>();

    public override void AssetsLoaded(ICoreAPI api)
    {
        ItemTransformations = api.Assets.Get(new AssetLocation("pei:config/groundstorage-transformations-for-items.json")).ToObject<Dictionary<string, ModelTransform>>();
        BlockTransformations = api.Assets.Get(new AssetLocation("pei:config/groundstorage-transformations-for-blocks.json")).ToObject<Dictionary<string, ModelTransform>>();

        DefaultBlacklistItems = api.Assets.Get(new AssetLocation("pei:config/default-blacklist-items.json")).ToObject<List<string>>();
        DefaultBlacklistBlocks = api.Assets.Get(new AssetLocation("pei:config/default-blacklist-blocks.json")).ToObject<List<string>>();

        DefaultGroundStorableItems = api.Assets.Get(new AssetLocation("pei:config/default-groundstorable-items.json")).ToObject<GroundStorables>();
        DefaultGroundStorableBlocks = api.Assets.Get(new AssetLocation("pei:config/default-groundstorable-blocks.json")).ToObject<GroundStorables>();
    }

    public override void AssetsFinalize(ICoreAPI api)
    {
        long elapsedMilliseconds = api.World.ElapsedMilliseconds;

        Config = ModConfig.ReadConfig<ConfigPlaceEveryItem>(api, "PlaceEveryItemConfig.json");

        Dictionary<string, GroundStorageProperties> items = Config.Items.GetPropsFromAll();
        Dictionary<string, GroundStorageProperties> blocks = Config.Blocks.GetPropsFromAll();

        foreach (CollectibleObject obj in api.World.Collectibles)
        {
            if (obj.Code == null || obj.Id == 0 || obj.IsGroundStorable()) continue;

            switch (obj.ItemClass)
            {
                case EnumItemClass.Block when !Config.BlacklistBlocks.Any(code => obj.WildCardMatch(AssetLocation.Create(code))):
                    foreach (KeyValuePair<string, GroundStorageProperties> props in blocks)
                    {
                        if (!obj.WildCardMatch(AssetLocation.Create(props.Key))) continue;
                        obj.AppendBehavior(props.Value);
                        obj.AddToCreativeInventory();
                        break;
                    }
                    foreach (KeyValuePair<string, ModelTransform> transform in BlockTransformations)
                    {
                        if (!obj.WildCardMatch(AssetLocation.Create(transform.Key))) continue;
                        obj.ApplyTransform(transform.Value);
                        break;
                    }
                    break;
                case EnumItemClass.Item when !Config.BlacklistItems.Any(code => obj.WildCardMatch(AssetLocation.Create(code))):

                    foreach (KeyValuePair<string, GroundStorageProperties> props in items)
                    {
                        if (!obj.WildCardMatch(AssetLocation.Create(props.Key))) continue;
                        obj.AppendBehavior(props.Value);
                        obj.AddToCreativeInventory();
                        break;
                    }
                    foreach (KeyValuePair<string, ModelTransform> transform in ItemTransformations)
                    {
                        if (!obj.WildCardMatch(AssetLocation.Create(transform.Key))) continue;
                        obj.ApplyTransform(transform.Value);
                        break;
                    }
                    break;
            }
        }

        Mod.Logger.Event("started '{0}' mod ({1} ms)", Mod.Info.Name, api.World.ElapsedMilliseconds - elapsedMilliseconds);
    }
}