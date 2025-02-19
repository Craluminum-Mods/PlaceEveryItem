using Vintagestory.API.Common;
using System.Collections.Generic;
using Vintagestory.API.Server;

[assembly: ModInfo(name: "Place Every Item", modID: "pei", Side = "Server")]

namespace PlaceEveryItem;

public class Core : ModSystem
{
    public static Config Config { get; private set; }

    public Dictionary<string, ModelTransform> Transformations { get; private set; }

    public Dictionary<string, bool> DefaultHalves { get; private set; }
    public Dictionary<string, bool> DefaultQuadrants { get; private set; }
    public Dictionary<string, bool> DefaultSingleCenter { get; private set; }
    public Dictionary<string, DataWallHalves> DefaultWallHalves { get; private set; }

    public override void AssetsFinalize(ICoreAPI api)
    {
        Config = ModConfig.ReadConfig(api as ICoreServerAPI);
        api.World.Logger.Event("started '{0}' mod", Mod.Info.Name);
    }

    public override void AssetsLoaded(ICoreAPI api)
    {
        Transformations = api.Assets.Get(new AssetLocation("pei:config/transformations.json")).ToObject<Dictionary<string, ModelTransform>>();

        DefaultHalves = api.Assets.Get(new AssetLocation("pei:config/default-halves.json")).ToObject<Dictionary<string, bool>>();
        DefaultQuadrants = api.Assets.Get(new AssetLocation("pei:config/default-quadrants.json")).ToObject<Dictionary<string, bool>>();
        DefaultSingleCenter = api.Assets.Get(new AssetLocation("pei:config/default-singlecenter.json")).ToObject<Dictionary<string, bool>>();
        DefaultWallHalves = api.Assets.Get(new AssetLocation("pei:config/default-wallhalves.json")).ToObject<Dictionary<string, DataWallHalves>>();
    }
}