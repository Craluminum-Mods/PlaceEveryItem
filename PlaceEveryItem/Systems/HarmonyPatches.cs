using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public class HarmonyPatches : ModSystem
{
    public const string HarmonyID = "craluminum2413.PlaceEveryItem";
    public static Harmony HarmonyInstance { get; set; } = new Harmony(HarmonyID);

    public override void StartPre(ICoreAPI api)
    {
        base.StartPre(api);
        HarmonyInstance.Patch(original: typeof(BlockGroundStorage).GetMethod(nameof(BlockGroundStorage.OnLoaded)), postfix: typeof(BlockGroundStorage_Init_Patch).GetMethod(nameof(BlockGroundStorage_Init_Patch.Postfix)));
        HarmonyInstance.Patch(original: typeof(ItemRope).GetMethod(nameof(ItemRope.OnHeldInteractStart)), prefix: typeof(ItemRope_OnHeldInteractStart_Patch).GetMethod(nameof(ItemRope_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(Block).GetMethod(nameof(Block.CanPlaceBlock)), prefix: typeof(Block_CanPlaceBlock_Patch).GetMethod(nameof(Block_CanPlaceBlock_Patch.Prefix)));

        HarmonyInstance.Patch(original: typeof(BlockSupportBeam).GetMethod(nameof(BlockSupportBeam.OnHeldInteractStart)), prefix: typeof(BlockSupportBeam_OnHeldInteractStart_Patch).GetMethod(nameof(BlockSupportBeam_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemCandle).GetMethod(nameof(ItemCandle.OnHeldInteractStart)), prefix: typeof(ItemCandle_OnHeldInteractStart_Patch).GetMethod(nameof(ItemCandle_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemCattailRoot).GetMethod(nameof(ItemCattailRoot.OnHeldInteractStart)), prefix: typeof(ItemCattailRoot_OnHeldInteractStart_Patch).GetMethod(nameof(ItemCattailRoot_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemClay).GetMethod(nameof(ItemClay.OnHeldInteractStart)), prefix: typeof(ItemClay_OnHeldInteractStart_Patch).GetMethod(nameof(ItemClay_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemClosedBeenade).GetMethod(nameof(ItemClosedBeenade.OnHeldInteractStart)), prefix: typeof(ItemClosedBeenade_OnHeldInteractStart_Patch).GetMethod(nameof(ItemClosedBeenade_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemDough).GetMethod(nameof(ItemDough.OnHeldInteractStart)), prefix: typeof(ItemDough_OnHeldInteractStart_Patch).GetMethod(nameof(ItemDough_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemDryGrass).GetMethod(nameof(ItemDryGrass.OnHeldInteractStart)), prefix: typeof(ItemDryGrass_OnHeldInteractStart_Patch).GetMethod(nameof(ItemDryGrass_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemFlint).GetMethod(nameof(ItemFlint.OnHeldInteractStart)), prefix: typeof(ItemFlint_OnHeldInteractStart_Patch).GetMethod(nameof(ItemFlint_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemHoneyComb).GetMethod(nameof(ItemHoneyComb.OnHeldInteractStart)), prefix: typeof(ItemHoneyComb_OnHeldInteractStart_Patch).GetMethod(nameof(ItemHoneyComb_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemOpenedBeenade).GetMethod(nameof(ItemOpenedBeenade.OnHeldInteractStart)), prefix: typeof(ItemOpenedBeenade_OnHeldInteractStart_Patch).GetMethod(nameof(ItemOpenedBeenade_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemPileable).GetMethod(nameof(ItemPileable.OnHeldInteractStart)), prefix: typeof(ItemPileable_OnHeldInteractStart_Patch).GetMethod(nameof(ItemPileable_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemPlantableSeed).GetMethod(nameof(ItemPlantableSeed.OnHeldInteractStart)), prefix: typeof(ItemPlantableSeed_OnHeldInteractStart_Patch).GetMethod(nameof(ItemPlantableSeed_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemPoultice).GetMethod(nameof(ItemPoultice.OnHeldInteractStart)), prefix: typeof(ItemPoultice_OnHeldInteractStart_Patch).GetMethod(nameof(ItemPoultice_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemRustyGear).GetMethod(nameof(ItemRustyGear.OnHeldInteractStart)), prefix: typeof(ItemRustyGear_OnHeldInteractStart_Patch).GetMethod(nameof(ItemRustyGear_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemSling).GetMethod(nameof(ItemSling.OnHeldInteractStart)), prefix: typeof(ItemSling_OnHeldInteractStart_Patch).GetMethod(nameof(ItemSling_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemTemporalGear).GetMethod(nameof(ItemTemporalGear.OnHeldInteractStart)), prefix: typeof(ItemTemporalGear_OnHeldInteractStart_Patch).GetMethod(nameof(ItemTemporalGear_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(ItemTreeSeed).GetMethod(nameof(ItemTreeSeed.OnHeldInteractStart)), prefix: typeof(ItemTreeSeed_OnHeldInteractStart_Patch).GetMethod(nameof(ItemTreeSeed_OnHeldInteractStart_Patch.Prefix)));
    }

    public override void Dispose()
    {
        HarmonyInstance.Unpatch(original: typeof(BlockGroundStorage).GetMethod(nameof(BlockGroundStorage.OnLoaded)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemRope).GetMethod(nameof(ItemRope.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(Block).GetMethod(nameof(Block.CanPlaceBlock)), type: HarmonyPatchType.All, HarmonyID);

        HarmonyInstance.Unpatch(original: typeof(BlockSupportBeam).GetMethod(nameof(BlockSupportBeam.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemCandle).GetMethod(nameof(ItemCandle.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemCattailRoot).GetMethod(nameof(ItemCattailRoot.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemClay).GetMethod(nameof(ItemClay.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemClosedBeenade).GetMethod(nameof(ItemClosedBeenade.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemDough).GetMethod(nameof(ItemDough.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemDryGrass).GetMethod(nameof(ItemDryGrass.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemFlint).GetMethod(nameof(ItemFlint.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemHoneyComb).GetMethod(nameof(ItemHoneyComb.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemOpenedBeenade).GetMethod(nameof(ItemOpenedBeenade.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemPileable).GetMethod(nameof(ItemPileable.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemPlantableSeed).GetMethod(nameof(ItemPlantableSeed.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemPoultice).GetMethod(nameof(ItemPoultice.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemRustyGear).GetMethod(nameof(ItemRustyGear.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemSling).GetMethod(nameof(ItemSling.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemTemporalGear).GetMethod(nameof(ItemTemporalGear.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemTreeSeed).GetMethod(nameof(ItemTreeSeed.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        base.Dispose();
    }
}