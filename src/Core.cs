using System.Collections.Generic;
using Vintagestory.API.Common;
using IWannaPlaceEveryItem.Constructor;
using IWannaPlaceEveryItem.List;

[assembly: ModInfo("IWannaPlaceEveryItem",
  Description = "Adds the ability to place almost any item on the ground",
  Website = "https://github.com/Craluminum2413/IWannaPlaceEveryItem",
  Authors = new[] { "Craluminum2413" })]

namespace IWannaPlaceEveryItem
{
  public class Core : ModSystem
	{
    public override void StartPre(ICoreAPI api)
		{
			base.StartPre(api);

			IWannaPlaceEveryItemConfig settingsFromDisk;

			try
			{
				settingsFromDisk = api.LoadModConfig<IWannaPlaceEveryItemConfig>("IWannaPlaceEveryItemConfig.json");
			}
			catch
			{
				settingsFromDisk = null;
			}

			if (settingsFromDisk is null)
			{
				settingsFromDisk = IWannaPlaceEveryItemConfig.Loaded;
				api.StoreModConfig<IWannaPlaceEveryItemConfig>(IWannaPlaceEveryItemConfig.Loaded, "IWannaPlaceEveryItemConfig.json");
			}

			foreach (KeyValuePair<string, Part> p in settingsFromDisk)
			{
				api.World.Config.SetBool($"Place{p.Key}Enabled", p.Value.Enabled);
			}
		}
	}
}