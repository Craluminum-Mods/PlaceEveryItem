using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using PlaceEveryItem.Constructor;
using Vintagestory.API.Common;

namespace PlaceEveryItem.List
{
  [JsonObject]
	public class PlaceEveryItemConfig : ModSystem, IEnumerable<KeyValuePair<string, Part>>
	{
		public static PlaceEveryItemConfig Loaded { get; set; } = new PlaceEveryItemConfig();
		private const string mp = " (check morepiles)";
		private const string allt = "All types of ";
		private const string sc = "1";
		private const string hv = "2";
		private const string qr = "4";

		// Foods
		public Part Bread { get; set; } = new Part(true, $"{qr} (All)");
		public Part Butter { get; set; } = new Part(true, $"{qr}");
		public Part Dough { get; set; } = new Part(true, $"{qr} (All)");
		public Part Egg { get; set; } = new Part(true, $"{qr}");
		public Part Flour { get; set; } = new Part(true, $"{qr} (All)");
		public Part Fruit { get; set; } = new Part(true, $"{qr} (All)");
		public Part Grain { get; set; } = new Part(true, $"{qr} (All)");
		public Part Insect { get; set; } = new Part(true, $"{qr}");
		public Part Legume { get; set; } = new Part(true, $"{qr} (All)");
		public Part Meat { get; set; } = new Part(true, $"{qr} (bushmeat, redmeat, poultry)");
		public Part PickledFood { get; set; } = new Part(true, $"{qr}");
		public Part PressedMash { get; set; } = new Part(true, $"{qr}");
		public Part Vegetable { get; set; } = new Part(true, $"{qr} (All, including raw cassava)");

		// Toolheads
		public Part ArrowHead { get; set; } = new Part(true, $"{qr}");
		public Part AxeHead { get; set; } = new Part(true, $"{qr}");
		public Part HammerHead { get; set; } = new Part(true, $"{qr}");
		public Part HoeHead { get; set; } = new Part(true, $"{qr}");
		public Part KnifeBlade { get; set; } = new Part(true, $"{qr}");
		public Part LongbladeHead { get; set; } = new Part(true, $"{qr}");
		public Part PickaxeHead { get; set; } = new Part(true, $"{qr}");
		public Part PropickHead { get; set; } = new Part(true, $"{qr}");
		public Part SawBlade { get; set; } = new Part(true, $"{qr}");
		public Part ScytheHead { get; set; } = new Part(true, $"{qr}");
		public Part ShovelHead { get; set; } = new Part(true, $"{qr}");
		public Part SpearHead { get; set; } = new Part(true, $"{qr}");
		public Part HelveHammerHead { get; set; } = new Part(true, $"{qr}");
		public Part Bowstave { get; set; } = new Part(true, $"{sc}");
		//TODO:Combine items above into Toolheads
		// public Part Toolheads { get; set; } = new Part(true, $"{qr} (all except pounder cap and pulv.toggle)");
		public Part PounderCap { get; set; } = new Part(true, $"{qr}");
		public Part PulverizerToggle { get; set; } = new Part(true, $"{qr}");

		// Other
		public Part Bandage { get; set; } = new Part(true, $"{qr}");
		public Part Bullets { get; set; } = new Part(true, $"{qr}");
		public Part ReedTops { get; set; } = new Part(true, $"{qr} (cattail, papyrus)");
		public Part DryGrass { get; set; } = new Part(true, $"{qr}");
		public Part Fat { get; set; } = new Part(true, $"{qr}");
		public Part Feather { get; set; } = new Part(true, $"{qr}");
		public Part Gear { get; set; } = new Part(true, $"{qr} (rusty, temporal)");
		public Part GemRough { get; set; } = new Part(true, $"{qr}");
		public Part Hide { get; set; } = new Part(true, $"{qr}");
		public Part LargeGearSection { get; set; } = new Part(true, $"{qr}");
		public Part Leather { get; set; } = new Part(true, $"{qr}");
		public Part NuggetBit { get; set; } = new Part(true, $"{qr} (metal bits, nuggets)");
		public Part OreBlastingBomb { get; set; } = new Part(true, $"{qr}");
		public Part OreChunk { get; set; } = new Part(true, $"{qr} ({allt}graded/ungraded/crystalized)");
		public Part Padlock { get; set; } = new Part(true, $"{qr}");
		public Part Paper { get; set; } = new Part(true, $"{qr}");
		public Part Quartz { get; set; } = new Part(true, $"{qr} (amethyst, clear, rose, smoky)");
		public Part Quiver { get; set; } = new Part(true, $"{sc}");
		public Part Resin { get; set; } = new Part(true, $"{qr}");
		public Part ResonanceArchive { get; set; } = new Part(true, $"{qr}");
		public Part Rot { get; set; } = new Part(true, $"{qr}");
		public Part Seeds { get; set; } = new Part(true, $"{qr}");
		public Part SewingKit { get; set; } = new Part(true, $"{qr}");
		public Part SolderBar { get; set; } = new Part(true, $"{qr}");
		public Part TreeSeed { get; set; } = new Part(true, $"{qr}");
		public Part ReedRoots { get; set; } = new Part(true, $"{qr}");
		public Part MetalPartsAndScraps { get; set; } = new Part(true, $"{qr}");
		public Part SeaShell { get; set; } = new Part(true, $"{qr}");
		public Part OilLamp { get; set; } = new Part(true, $"{qr}");
		public Part FruitTreeBranch { get; set; } = new Part(true, $"{qr}");
		public Part Torch { get; set; } = new Part(true, $"{qr}");
		public Part Beenade { get; set; } = new Part(true, $"{qr}");
		public Part Candle { get; set; } = new Part(true, $"{qr}");
		public Part Planter { get; set; } = new Part(true, $"{qr}");
		public Part Distiller { get; set; } = new Part(true, $"{qr} (condenser, boiler)");
		public Part BloomeryParts { get; set; } = new Part(true, $"{qr} (base, chimney)");
		public Part Chimney { get; set; } = new Part(true, $"{qr}");
		public Part DisplayCase { get; set; } = new Part(true, $"{qr}");
		public Part StorageVessel { get; set; } = new Part(true, $"{qr}");
		public Part Quern { get; set; } = new Part(true, $"{qr}");
		public Part Mechanics { get; set; } = new Part(true, $"{qr} (All except axle and angled gear)");
		public Part Chest { get; set; } = new Part(true, $"{qr} (All)");
		public Part Table { get; set; } = new Part(true, $"{qr}");
		public Part ReedBasket { get; set; } = new Part(true, $"{qr}");
		public Part StoneCoffinBoth { get; set; } = new Part(true, $"{qr}");
		public Part Crystal { get; set; } = new Part(true, $"{qr} (All)");
		public Part MoldRack { get; set; } = new Part(true, $"{qr}");
		public Part Shelf { get; set; } = new Part(true, $"{qr}");
		public Part Bed { get; set; } = new Part(true, $"{qr}");
		public Part Barrel { get; set; } = new Part(true, $"{qr}");
		public Part Chair { get; set; } = new Part(true, $"{qr}");
		public Part Door { get; set; } = new Part(true, $"{qr}");
		public Part EchoChamber { get; set; } = new Part(true, $"{qr}");
		public Part FruitPress { get; set; } = new Part(true, $"{qr}");
		public Part Omok { get; set; } = new Part(true, $"{qr}");
		public Part WoodenPath { get; set; } = new Part(true, $"{qr}");
		public Part SignPost { get; set; } = new Part(true, $"{qr}");
		public Part SticksLayer { get; set; } = new Part(true, $"{qr}");



		// Has pile in More Piles 1.2.0+
		public Part AngledGear { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Arrow { get; set; } = new Part(false, $"{qr} (any arrow, even modded ones),{mp}");
		public Part Axle { get; set; } = new Part(false, $"{qr},{mp}");
		public Part BambooStakes { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Beeswax { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Bone { get; set; } = new Part(false, $"{qr},{mp}");
		public Part ChuteSection { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Cloth { get; set; } = new Part(false, $"{qr},{mp}");
		public Part FlaxFibers { get; set; } = new Part(false, $"{qr},{mp}");
		public Part FlaxTwine { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Honeycomb { get; set; } = new Part(false, $"{qr},{mp}");
		public Part IronBloom { get; set; } = new Part(false, $"{qr},{mp}");
		public Part MetalChain { get; set; } = new Part(false, $"{qr},{mp}");
		public Part MetalLamellae { get; set; } = new Part(false, $"{qr},{mp}");
		public Part MetalScales { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Poultice { get; set; } = new Part(true, $"{qr},{mp}"); // Not used as pile currently
		public Part Sail { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Stick { get; set; } = new Part(false, $"{qr},{mp}");
		public Part TorchHolder { get; set; } = new Part(false, $"{qr},{mp}");		
		public Part TroughLarge { get; set; } = new Part(false, $"{qr},{mp}");
		public Part TroughSmall { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Painting { get; set; } = new Part(false, $"{qr},{mp}");
		public Part FlowerPot { get; set; } = new Part(true, $"{qr},{mp}"); // Not used as pile currently




		private static readonly PropertyInfo[] propertyInfos = typeof(PlaceEveryItemConfig).GetProperties()
			.Where(propertyInfo => propertyInfo.PropertyType == typeof(Part)).ToArray();

		public IEnumerator<KeyValuePair<string, Part>> GetEnumerator()
		{
			return propertyInfos.Select(propertyInfo => new KeyValuePair<string, Part>(propertyInfo.Name, (Part)propertyInfo.GetValue(this))).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}