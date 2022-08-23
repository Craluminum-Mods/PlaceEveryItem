namespace PlaceEveryItem.Configuration
{
  class PlaceEveryItemConfig
  {
    public bool Bandage = true;
    public bool Beenade = true;
    public bool Candle = true;
    public bool DryGrass = true;
    public bool Fat = true;
    public bool Feather = true;
    public bool Flowerpot = true;
    public bool FruitTreeBranch = true;
    public readonly string GearComment = "rusty, temporal";
    public bool Gear = true;
    public bool GemRough = true;
    public bool Hide = true;
    public bool Honeycomb = true;
    public bool Leather = true;
    public bool MetalPartsAndScraps = true;
    public bool NuggetMetalBits = true;
    public bool OilLamp = true;
    public bool OreBlastingBomb = true;
    public bool OreChunk = true;
    public bool Padlock = true;
    public bool Paper = true;
    public readonly string PerishableFoodComment = "bread, butter, dough, egg, flour, fruits, grains, insects, legumes, meat, pickled, mash, vegetable";
    public bool PerishableFood = true;
    public bool Poultice = true;
    public bool Quartz = true;
    public bool ReedRoots = true;
    public bool ReedTops = true;
    public bool Resin = true;
    public bool ResonanceArchive = true;
    public bool Rot = true;
    public bool SeaShell = true;
    public bool Seeds = true;
    public bool SewingKit = true;
    public bool SolderBar = true;
    public bool Toolheads = true;
    public bool TreeSeed = true;
    public readonly string HavePilesInMorePiles = "These items have piles in More Piles";
    public bool AngledGear;
    public bool Arrow;
    public bool Axle;
    public bool BambooStakes;
    public bool Beeswax;
    public bool Bone;
    public bool ChuteSection;
    public bool Cloth;
    public bool FlaxFibers;
    public bool FlaxTwine;
    public bool IronBloom;
    public bool MetalChain;
    public bool MetalLamellae;
    public bool MetalScales;
    public bool Painting;
    public bool Sail;
    public bool Stick;
    public bool TorchHolder;
    public bool TroughLarge;
    public bool TroughSmall;

    public PlaceEveryItemConfig() { }

    public PlaceEveryItemConfig(PlaceEveryItemConfig previousConfig)
    {
      Bandage = previousConfig.Bandage;
      Beenade = previousConfig.Beenade;
      Candle = previousConfig.Candle;
      DryGrass = previousConfig.DryGrass;
      Fat = previousConfig.Fat;
      Feather = previousConfig.Feather;
      Flowerpot = previousConfig.Flowerpot;
      FruitTreeBranch = previousConfig.FruitTreeBranch;
      Gear = previousConfig.Gear;
      GearComment = previousConfig.GearComment;
      GemRough = previousConfig.GemRough;
      Hide = previousConfig.Hide;
      Honeycomb = previousConfig.Honeycomb;
      Leather = previousConfig.Leather;
      MetalPartsAndScraps = previousConfig.MetalPartsAndScraps;
      NuggetMetalBits = previousConfig.NuggetMetalBits;
      OilLamp = previousConfig.OilLamp;
      OreBlastingBomb = previousConfig.OreBlastingBomb;
      OreChunk = previousConfig.OreChunk;
      Padlock = previousConfig.Padlock;
      Paper = previousConfig.Paper;
      PerishableFood = previousConfig.PerishableFood;
      PerishableFoodComment = previousConfig.PerishableFoodComment;
      Poultice = previousConfig.Poultice;
      Quartz = previousConfig.Quartz;
      ReedRoots = previousConfig.ReedRoots;
      ReedTops = previousConfig.ReedTops;
      Resin = previousConfig.Resin;
      ResonanceArchive = previousConfig.ResonanceArchive;
      Rot = previousConfig.Rot;
      SeaShell = previousConfig.SeaShell;
      Seeds = previousConfig.Seeds;
      SewingKit = previousConfig.SewingKit;
      SolderBar = previousConfig.SolderBar;
      Toolheads = previousConfig.Toolheads;
      TreeSeed = previousConfig.TreeSeed;

      HavePilesInMorePiles = previousConfig.HavePilesInMorePiles;
      AngledGear = previousConfig.AngledGear;
      Arrow = previousConfig.Arrow;
      Axle = previousConfig.Axle;
      BambooStakes = previousConfig.BambooStakes;
      Beeswax = previousConfig.Beeswax;
      Bone = previousConfig.Bone;
      ChuteSection = previousConfig.ChuteSection;
      Cloth = previousConfig.Cloth;
      FlaxFibers = previousConfig.FlaxFibers;
      FlaxTwine = previousConfig.FlaxTwine;
      IronBloom = previousConfig.IronBloom;
      MetalChain = previousConfig.MetalChain;
      MetalLamellae = previousConfig.MetalLamellae;
      MetalScales = previousConfig.MetalScales;
      Painting = previousConfig.Painting;
      Sail = previousConfig.Sail;
      Stick = previousConfig.Stick;
      TorchHolder = previousConfig.TorchHolder;
      TroughLarge = previousConfig.TroughLarge;
      TroughSmall = previousConfig.TroughSmall;
    }
  }
}