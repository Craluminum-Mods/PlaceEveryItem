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
		private const string allt = "All types of ";
		private const string foodlist = "bread, butter, dough, egg, flour, fruits, grains, insects, legumes, meat, pickled, mash, vegetable";
		private const string hv = "2";
		private const string mp = " (check morepiles)";
		private const string qr = "4";
		private const string sc = "1";

		// Foods
		public Part Fat { get; set; } = new Part(true, $"{qr}");
		public Part Food { get; set; } = new Part(true, $"{qr} ({foodlist})");
		public Part ReedRoots { get; set; } = new Part(true, $"{qr}");

		// Toolheads
		public Part Bowstave { get; set; } = new Part(true, $"{qr}");
		public Part PounderCap { get; set; } = new Part(true, $"{qr}");
		public Part PulverizerToggle { get; set; } = new Part(true, $"{qr}");
		public Part Toolheads { get; set; } = new Part(true, $"{qr} (all except pounder cap, pulv.toggle, bowstave)");
	
		/// Blocks (not all, but those that are not immersive to place)
		public Part AnvilEtc { get; set; } = new Part(false, $"{qr} (including anvil parts)");
		public Part Barrel { get; set; } = new Part(true, $"{qr}");
		public Part Bed { get; set; } = new Part(true, $"{qr}");
		public Part BloomeryParts { get; set; } = new Part(true, $"{qr} (base, chimney)");		
		public Part Chair { get; set; } = new Part(true, $"{qr}");
		public Part Chandelier { get; set; } = new Part(true, $"{qr}");
		public Part Chest { get; set; } = new Part(true, $"{qr} (All)");
		public Part Chimney { get; set; } = new Part(true, $"{qr}");
		public Part ChutesEtc { get; set; } = new Part(true, $"{qr} (including archimedes screw)");
		public Part DisplayCase { get; set; } = new Part(true, $"{qr}");
		public Part Distiller { get; set; } = new Part(true, $"{qr} (condenser, boiler)");
		public Part Door { get; set; } = new Part(true, $"{qr} (wooden, rough, iron, coke oven)");
		public Part EchoChamber { get; set; } = new Part(true, $"{qr}");
		public Part FruitPress { get; set; } = new Part(true, $"{qr}");
		public Part Hopper { get; set; } = new Part(true, $"{qr}");
		public Part Mechanics { get; set; } = new Part(true, $"{qr} (All except axle and angled gear)");
		public Part MetalBlock { get; set; } = new Part(true, $"{qr}");
		public Part MoldRack { get; set; } = new Part(true, $"{qr}");
		public Part Omok { get; set; } = new Part(true, $"{qr}");
		public Part Planter { get; set; } = new Part(true, $"{qr}");
		public Part Quern { get; set; } = new Part(true, $"{qr}");
		public Part ReedBasket { get; set; } = new Part(true, $"{qr}");
		public Part Shelf { get; set; } = new Part(true, $"{qr}");
		public Part SignPost { get; set; } = new Part(true, $"{qr}");
		public Part SticksLayer { get; set; } = new Part(true, $"{qr}");
		public Part StoneCoffinBoth { get; set; } = new Part(true, $"{qr}");
		public Part StorageVessel { get; set; } = new Part(true, $"{qr}");
		public Part Table { get; set; } = new Part(true, $"{qr}");
		public Part Torch { get; set; } = new Part(true, $"{qr}");
		public Part WoodenPath { get; set; } = new Part(true, $"{qr}");

		// Other
		public Part Bandage { get; set; } = new Part(true, $"{qr}");
		public Part Beenade { get; set; } = new Part(true, $"{qr}");
		public Part Bullets { get; set; } = new Part(true, $"{qr}");
		public Part Candle { get; set; } = new Part(true, $"{qr}");
		public Part Crystal { get; set; } = new Part(true, $"{qr} (All)");
		public Part DryGrass { get; set; } = new Part(true, $"{qr}");
		public Part Feather { get; set; } = new Part(true, $"{qr}");
		public Part FlowerPot { get; set; } = new Part(true, $"{qr}");
		public Part FruitTreeBranch { get; set; } = new Part(true, $"{qr}");
		public Part Gear { get; set; } = new Part(true, $"{qr} (rusty, temporal)");
		public Part GemRough { get; set; } = new Part(true, $"{qr}");
		public Part Hide { get; set; } = new Part(true, $"{qr}");
		public Part Honeycomb { get; set; } = new Part(true, $"{qr}");
		public Part LargeGearSection { get; set; } = new Part(true, $"{qr}");
		public Part Leather { get; set; } = new Part(true, $"{qr}");
		public Part MetalPartsAndScraps { get; set; } = new Part(true, $"{qr}");
		public Part NuggetBit { get; set; } = new Part(true, $"{qr} (metal bits, nuggets)");
		public Part OilLamp { get; set; } = new Part(true, $"{qr}");
		public Part OreBlastingBomb { get; set; } = new Part(true, $"{qr}");
		public Part OreChunk { get; set; } = new Part(true, $"{qr} ({allt}graded/ungraded/crystalized)");
		public Part Padlock { get; set; } = new Part(true, $"{qr}");
		public Part Paper { get; set; } = new Part(true, $"{qr}");
		public Part Poultice { get; set; } = new Part(true, $"{qr}");
		public Part Quartz { get; set; } = new Part(true, $"{qr} (amethyst, clear, rose, smoky)");
		public Part Quiver { get; set; } = new Part(true, $"{sc}");
		public Part ReedTops { get; set; } = new Part(true, $"{qr} (cattail, papyrus)");
		public Part Resin { get; set; } = new Part(true, $"{qr}");
		public Part ResonanceArchive { get; set; } = new Part(true, $"{qr}");
		public Part Rot { get; set; } = new Part(true, $"{qr}");
		public Part SeaShell { get; set; } = new Part(true, $"{qr}");
		public Part Seeds { get; set; } = new Part(true, $"{qr}");
		public Part SewingKit { get; set; } = new Part(true, $"{qr}");
		public Part SolderBar { get; set; } = new Part(true, $"{qr}");
		public Part TreeSeed { get; set; } = new Part(true, $"{qr}");

		// Has pile in More Piles 1.2.1+
		public Part AngledGear { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Arrow { get; set; } = new Part(false, $"{qr} (even modded ones),{mp}");
		public Part Axle { get; set; } = new Part(false, $"{qr},{mp}");
		public Part BambooStakes { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Beeswax { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Bone { get; set; } = new Part(false, $"{qr},{mp}");
		public Part ChuteSection { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Cloth { get; set; } = new Part(false, $"{qr},{mp}");
		public Part FlaxFibers { get; set; } = new Part(false, $"{qr},{mp}");
		public Part FlaxTwine { get; set; } = new Part(false, $"{qr},{mp}");
		public Part IronBloom { get; set; } = new Part(false, $"{qr},{mp}");
		public Part MetalChain { get; set; } = new Part(false, $"{qr},{mp}");
		public Part MetalLamellae { get; set; } = new Part(false, $"{qr},{mp}");
		public Part MetalScales { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Painting { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Sail { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Stick { get; set; } = new Part(false, $"{qr},{mp}");
		public Part TorchHolder { get; set; } = new Part(false, $"{qr},{mp}");
		public Part TroughLarge { get; set; } = new Part(false, $"{qr},{mp}");
		public Part TroughSmall { get; set; } = new Part(false, $"{qr},{mp}");

		private static readonly PropertyInfo[] propertyInfos = typeof(PlaceEveryItemConfig).GetProperties()
			.Where(propertyInfo => propertyInfo.PropertyType == typeof(Part)).ToArray();

		public IEnumerator<KeyValuePair<string, Part>> GetEnumerator()
		{
			return propertyInfos.Select(propertyInfo => new KeyValuePair<string, Part>(propertyInfo.Name, (Part)propertyInfo.GetValue(this))).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}