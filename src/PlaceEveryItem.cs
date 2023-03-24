using Vintagestory.API.Common;
using PlaceEveryItem.Configuration;
using System.Collections.Generic;
using Vintagestory.API.Datastructures;
using Newtonsoft.Json.Linq;

[assembly: ModInfo("Place Every Item",
    Authors = new[] { "Craluminum2413" })]

namespace PlaceEveryItem
{
    public class PlaceEveryItem : ModSystem
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
            transformations = LoadObjectFromJson<Dictionary<string, ModelTransform>>(api, "pei:config/transformations.json");
        }

        private T LoadObjectFromJson<T>(ICoreAPI api, string path)
        {
            var jsonObject = new JsonObject(api.Assets.Get<JToken>(new AssetLocation(path)));
            return jsonObject.Token.ToObject<T>();
        }
    }
}