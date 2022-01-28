using System.Collections.Generic;
using Vintagestory.API.Common;
using PlaceEveryItem.Constructor;
using PlaceEveryItem.List;

[assembly: ModInfo("PlaceEveryItem",
  Description = "Adds the ability to place almost any item on the ground",
  Website = "https://github.com/Craluminum2413/PlaceEveryItem",
  Authors = new[] { "Craluminum2413" })]

namespace PlaceEveryItem
{
  public class Configuration : ModSystem
	{
    public override void StartPre(ICoreAPI api)
		{
			base.StartPre(api);

			PlaceEveryItemConfig settingsFromDisk;

			try
			{
				settingsFromDisk = api.LoadModConfig<PlaceEveryItemConfig>("PlaceEveryItemConfig.json");
			}
			catch
			{
				settingsFromDisk = null;
			}

			if (settingsFromDisk is null)
			{
				settingsFromDisk = PlaceEveryItemConfig.Loaded;
				api.StoreModConfig<PlaceEveryItemConfig>(PlaceEveryItemConfig.Loaded, "PlaceEveryItemConfig.json");
			}

			foreach (KeyValuePair<string, Part> p in settingsFromDisk)
			{
				api.World.Config.SetBool($"Place{p.Key}Enabled", p.Value.Enabled);
			}
		}
	}
}