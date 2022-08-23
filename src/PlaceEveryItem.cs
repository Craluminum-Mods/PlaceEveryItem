using PlaceEveryItem.Configuration;
using Vintagestory.API.Common;

[assembly: ModInfo("Place Every Item",
  Authors = new[] { "Craluminum2413" })]

namespace PlaceEveryItem
{
  class PlaceEveryItem : ModSystem
  {
    public override void Start(ICoreAPI api)
    {
      base.Start(api);
      ModConfig.ReadConfig(api);
      api.World.Logger.Event("started 'Place Every Item' mod");
    }
  }
}