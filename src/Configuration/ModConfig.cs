using Vintagestory.API.Common;

namespace PlaceEveryItem.Configuration
{
  static class ModConfig
  {
    private const string jsonConfig = "PlaceEveryItemConfig.json";
    private static PlaceEveryItemConfig config;

    public static void ReadConfig(ICoreAPI api)
    {
      try
      {
        config = LoadConfig(api);

        if (config == null)
        {
          GenerateConfig(api);
          config = LoadConfig(api);
        }
        else
        {
          GenerateConfig(api, config);
        }
      }
      catch
      {
        GenerateConfig(api);
        config = LoadConfig(api);
      }

      api.World.Config.SetBool("PlaceBandageEnabled", config.Bandage);
      api.World.Config.SetBool("PlaceBeenadeEnabled", config.Beenade);
      api.World.Config.SetBool("PlaceCandleEnabled", config.Candle);
      api.World.Config.SetBool("PlaceDryGrassEnabled", config.DryGrass);
      api.World.Config.SetBool("PlaceFatEnabled", config.Fat);
      api.World.Config.SetBool("PlaceFeatherEnabled", config.Feather);
      api.World.Config.SetBool("PlaceFlowerpotEnabled", config.Flowerpot);
      api.World.Config.SetBool("PlaceFruitTreeBranchEnabled", config.FruitTreeBranch);
      api.World.Config.SetBool("PlaceGearEnabled", config.Gear);
      api.World.Config.SetBool("PlaceGemRoughEnabled", config.GemRough);
      api.World.Config.SetBool("PlaceHideEnabled", config.Hide);
      api.World.Config.SetBool("PlaceHoneycombEnabled", config.Honeycomb);
      api.World.Config.SetBool("PlaceLeatherEnabled", config.Leather);
      api.World.Config.SetBool("PlaceMetalPartsAndScrapsEnabled", config.MetalPartsAndScraps);
      api.World.Config.SetBool("PlaceNuggetMetalBitsEnabled", config.NuggetMetalBits);
      api.World.Config.SetBool("PlaceOilLampEnabled", config.OilLamp);
      api.World.Config.SetBool("PlaceOreBlastingBombEnabled", config.OreBlastingBomb);
      api.World.Config.SetBool("PlaceOreChunkEnabled", config.OreChunk);
      api.World.Config.SetBool("PlacePadlockEnabled", config.Padlock);
      api.World.Config.SetBool("PlacePaperEnabled", config.Paper);
      api.World.Config.SetBool("PlacePerishableFoodEnabled", config.PerishableFood);
      api.World.Config.SetBool("PlacePoulticeEnabled", config.Poultice);
      api.World.Config.SetBool("PlaceQuartzEnabled", config.Quartz);
      api.World.Config.SetBool("PlaceReedRootsEnabled", config.ReedRoots);
      api.World.Config.SetBool("PlaceReedTopsEnabled", config.ReedTops);
      api.World.Config.SetBool("PlaceResinEnabled", config.Resin);
      api.World.Config.SetBool("PlaceResonanceArchiveEnabled", config.ResonanceArchive);
      api.World.Config.SetBool("PlaceRotEnabled", config.Rot);
      api.World.Config.SetBool("PlaceSeaShellEnabled", config.SeaShell);
      api.World.Config.SetBool("PlaceSeedsEnabled", config.Seeds);
      api.World.Config.SetBool("PlaceSewingKitEnabled", config.SewingKit);
      api.World.Config.SetBool("PlaceSolderBarEnabled", config.SolderBar);
      api.World.Config.SetBool("PlaceToolheadsEnabled", config.Toolheads);
      api.World.Config.SetBool("PlaceTreeSeedEnabled", config.TreeSeed);
      api.World.Config.SetBool("PlaceAngledGearEnabled", config.AngledGear);
      api.World.Config.SetBool("PlaceArrowEnabled", config.Arrow);
      api.World.Config.SetBool("PlaceAxleEnabled", config.Axle);
      api.World.Config.SetBool("PlaceBambooStakesEnabled", config.BambooStakes);
      api.World.Config.SetBool("PlaceBeeswaxEnabled", config.Beeswax);
      api.World.Config.SetBool("PlaceBoneEnabled", config.Bone);
      api.World.Config.SetBool("PlaceChuteSectionEnabled", config.ChuteSection);
      api.World.Config.SetBool("PlaceClothEnabled", config.Cloth);
      api.World.Config.SetBool("PlaceFlaxFibersEnabled", config.FlaxFibers);
      api.World.Config.SetBool("PlaceFlaxTwineEnabled", config.FlaxTwine);
      api.World.Config.SetBool("PlaceIronBloomEnabled", config.IronBloom);
      api.World.Config.SetBool("PlaceMetalChainEnabled", config.MetalChain);
      api.World.Config.SetBool("PlaceMetalLamellaeEnabled", config.MetalLamellae);
      api.World.Config.SetBool("PlaceMetalScalesEnabled", config.MetalScales);
      api.World.Config.SetBool("PlaceSailEnabled", config.Sail);
      api.World.Config.SetBool("PlaceStickEnabled", config.Stick);
      api.World.Config.SetBool("PlaceTorchHolderEnabled", config.TorchHolder);
    }
    private static PlaceEveryItemConfig LoadConfig(ICoreAPI api) =>
      api.LoadModConfig<PlaceEveryItemConfig>(jsonConfig);

    private static void GenerateConfig(ICoreAPI api) =>
      api.StoreModConfig(new PlaceEveryItemConfig(), jsonConfig);

    private static void GenerateConfig(ICoreAPI api, PlaceEveryItemConfig previousConfig) =>
      api.StoreModConfig(new PlaceEveryItemConfig(previousConfig), jsonConfig);
  }
}