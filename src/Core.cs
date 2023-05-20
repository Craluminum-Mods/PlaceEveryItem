using Vintagestory.API.Common;
using PlaceEveryItem.Configuration;
using System.Collections.Generic;

[assembly: ModInfo("Place Every Item",
    Authors = new[] { "Craluminum2413" })]

namespace PlaceEveryItem
{
    public class Core : ModSystem
    {
        public Dictionary<string, ModelTransform> transformations = new();

        public override bool ShouldLoad(EnumAppSide forSide) => forSide == EnumAppSide.Server;

        public override void AssetsFinalize(ICoreAPI api)
        {
            ModConfig.ReadConfig(api);
            api.World.Logger.Event("started 'Place Every Item' mod");
        }

        public override void AssetsLoaded(ICoreAPI api)
        {
            transformations = api.Assets.Get(new AssetLocation("pei:config/transformations.json")).ToObject<Dictionary<string, ModelTransform>>();
        }
    }
}