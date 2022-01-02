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
		private const string mp = " (More Piles has a pile for it)";
		private const string allt = "All types of ";
		private const string sc = "SingleCenter";
		private const string hv = "Halves";
		private const string qr = "Quadrants";

		// Foods
		public Part Bread { get; set; } = new Part(true, $"{qr} ({allt}bread)");
		public Part Butter { get; set; } = new Part(true, $"{qr}");
		public Part Dough { get; set; } = new Part(true, $"{qr} ({allt}dough)");
		public Part Egg { get; set; } = new Part(true, $"{qr}");
		public Part Flour { get; set; } = new Part(true, $"{qr} ({allt}flour)");
		public Part Fruit { get; set; } = new Part(true, $"{qr} (All fruits)");
		public Part Grain { get; set; } = new Part(true, $"{qr} ({allt}grain)");
		public Part Insect { get; set; } = new Part(true, $"{qr}");
		public Part Legume { get; set; } = new Part(true, $"{qr} (All legumes)");
		public Part Meat { get; set; } = new Part(true, $"{qr} (bushmeat, redmeat, poultry)");
		public Part PickledLegume { get; set; } = new Part(true, $"{qr} (All pickled legumes)");
		public Part PickledVegetable { get; set; } = new Part(true, $"{qr} (All pickled vegetables)");
		public Part PressedMash { get; set; } = new Part(true, $"{qr}");
		public Part RawCassava { get; set; } = new Part(true, $"{qr}");
		public Part Vegetable { get; set; } = new Part(true, $"{qr} (All vegetables)");

		// Toolheads
		public Part ArrowHead { get; set; } = new Part(true, $"{qr}");
		public Part AxeHead { get; set; } = new Part(true, $"{qr}");
		public Part Bowstave { get; set; } = new Part(true, $"{sc}");
		public Part HammerHead { get; set; } = new Part(true, $"{qr}");
		public Part HelveHammerHead { get; set; } = new Part(true, $"{qr}");
		public Part HoeHead { get; set; } = new Part(true, $"{qr}");
		public Part KnifeBlade { get; set; } = new Part(true, $"{qr}");
		public Part LongbladeHead { get; set; } = new Part(true, $"{qr}");
		public Part PickaxeHead { get; set; } = new Part(true, $"{qr}");
		public Part PounderCap { get; set; } = new Part(true, $"{qr}");
		public Part PropickHead { get; set; } = new Part(true, $"{qr}");
		public Part PulverizerToggle { get; set; } = new Part(true, $"{qr}");
		public Part SawBlade { get; set; } = new Part(true, $"{qr}");
		public Part ScytheHead { get; set; } = new Part(true, $"{qr}");
		public Part ShovelHead { get; set; } = new Part(true, $"{qr} for metal, {qr} for stone");
		public Part SpearHead { get; set; } = new Part(true, $"{qr}");

		// Other
		public Part CattailTops { get; set; } = new Part(true, $"{qr}");
		public Part Fat { get; set; } = new Part(true, $"{qr}");
		public Part Feather { get; set; } = new Part(true, $"{qr}");
		public Part Gear { get; set; } = new Part(true, $"{qr} (rusty, temporal)");
		public Part GemRough { get; set; } = new Part(true, $"{qr}");
		public Part Hide { get; set; } = new Part(true, $"{qr}");
		public Part LargeGearSection { get; set; } = new Part(true, $"{qr}");
		public Part Leather { get; set; } = new Part(true, $"{qr}");
		public Part Metalbit { get; set; } = new Part(true, $"{qr}");
		public Part Nugget { get; set; } = new Part(true, $"{qr}");
		public Part OreChunk { get; set; } = new Part(true, $"{qr} ({allt}graded/ungraded/crystalized ore chunks)");
		public Part Padlock { get; set; } = new Part(true, $"{qr}");
		public Part PapyrusTops { get; set; } = new Part(true, $"{qr}");
		public Part Quartz { get; set; } = new Part(true, $"{qr} (amethyst, clear, rose, smoky)");
		public Part Quiver { get; set; } = new Part(true, $"{sc}");
		public Part Resin { get; set; } = new Part(true, $"{qr}");
		public Part ResonanceArchive { get; set; } = new Part(true, $"{qr}");
		public Part Seeds { get; set; } = new Part(true, $"{qr}");
		public Part SewingKit { get; set; } = new Part(true, $"{qr}");
		public Part SolderBar { get; set; } = new Part(true, $"{qr}");
		public Part TreeSeed { get; set; } = new Part(true, $"{qr}");
		public Part Bandage { get; set; } = new Part(true, $"{qr}");
		public Part Bullets { get; set; } = new Part(true, $"{qr}");
		public Part Paper { get; set; } = new Part(true, $"{qr}");
		public Part DryGrass { get; set; } = new Part(true, $"{qr}");
		public Part Rot { get; set; } = new Part(true, $"{qr}");
		public Part OreBlastingBomb { get; set; } = new Part(true, $"{qr}");

		// Has pile in More Piles 1.2.0+
		public Part AngledGear { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Axle { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Arrow { get; set; } = new Part(false, $"{qr} (any arrow, even modded ones),{mp}");
		public Part Bone { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Beeswax { get; set; } = new Part(false, $"{qr},{mp}");
		public Part BambooStakes { get; set; } = new Part(false, $"{qr},{mp}");
		public Part ChuteSection { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Cloth { get; set; } = new Part(false, $"{qr},{mp}");
		public Part FlaxFibers { get; set; } = new Part(false, $"{qr},{mp}");
		public Part FlaxTwine { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Honeycomb { get; set; } = new Part(false, $"{qr},{mp}");
		public Part IronBloom { get; set; } = new Part(false, $"{qr},{mp}");
		public Part MetalLamellae { get; set; } = new Part(false, $"{qr},{mp}");
		public Part MetalScales { get; set; } = new Part(false, $"{qr},{mp}");
		public Part MetalChain { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Poultice { get; set; } = new Part(true, $"{qr},{mp}"); // Not used as pile currently
		public Part Sail { get; set; } = new Part(false, $"{qr},{mp}");
		public Part Stick { get; set; } = new Part(false, $"{qr},{mp}");

		private static readonly PropertyInfo[] propertyInfos = typeof(PlaceEveryItemConfig).GetProperties()
			.Where(propertyInfo => propertyInfo.PropertyType == typeof(Part)).ToArray();

		public IEnumerator<KeyValuePair<string, Part>> GetEnumerator()
		{
			return propertyInfos.Select(propertyInfo => new KeyValuePair<string, Part>(propertyInfo.Name, (Part)propertyInfo.GetValue(this))).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}