using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

[HarmonyPatch]
public static class GroundStoragePatches
{
    [HarmonyPatch(typeof(ItemCandle), nameof(ItemCandle.OnHeldInteractStart))]
    public static class FixCandleGroundStoragePlacementPatch
    {
        public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
            => slot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handHandling);
    }

    [HarmonyPatch(typeof(ItemClay), nameof(ItemClay.OnHeldInteractStart))]
    public static class FixClayGroundStoragePlacementPatch
    {
        public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
            => slot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handling);
    }

    [HarmonyPatch(typeof(ItemSling), nameof(ItemSling.OnHeldInteractStart))]
    public static class FixSlingPlacement
    {
        public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
            => slot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handling);
    }

    [HarmonyPatch(typeof(ItemScrapWeaponKit), nameof(ItemScrapWeaponKit.OnHeldInteractStart))]
    public static class FixScrapWeaponKitGroundStoragePlacementPatch
    {
        public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
            => slot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handling);
    }

    [HarmonyPatch(typeof(ItemPlantableSeed), nameof(ItemPlantableSeed.OnHeldInteractStart))]
    public static class FixSeedGroundStoragePlacementPatch
    {
        public static bool Prefix(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
            => itemslot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handHandling);
    }

    [HarmonyPatch(typeof(ItemCattailRoot), nameof(ItemCattailRoot.OnHeldInteractStart))]
    public static class FixReedRootsGroundStoragePlacementPatch
    {
        public static bool Prefix(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
            => itemslot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handHandling);
    }

    [HarmonyPatch(typeof(ItemPoultice), nameof(ItemPoultice.OnHeldInteractStart))]
    public static class FixPoulticeGroundStoragePlacementPatch
    {
        public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
            => slot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handling);
    }

    [HarmonyPatch(typeof(ItemPileable), nameof(ItemPileable.OnHeldInteractStart))]
    public static class FixPileableGroundStoragePlacementPatch
    {
        public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
            => slot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handling);
    }

    [HarmonyPatch(typeof(ItemOpenedBeenade), nameof(ItemOpenedBeenade.OnHeldInteractStart))]
    public static class FixOpenedBeenadeGroundStoragePlacementPatch
    {
        public static bool Prefix(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
            => itemslot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handling);
    }

    [HarmonyPatch(typeof(ItemFlint), nameof(ItemFlint.OnHeldInteractStart))]
    public static class FixFlintGroundStoragePlacementPatch
    {
        public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
            => slot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handling);
    }

    [HarmonyPatch(typeof(ItemDryGrass), nameof(ItemDryGrass.OnHeldInteractStart))]
    public static class FixDryGrassGroundStoragePlacementPatch
    {
        public static bool Prefix(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
            => itemslot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handHandling);
    }

    [HarmonyPatch(typeof(ItemClosedBeenade), nameof(ItemClosedBeenade.OnHeldInteractStart))]
    public static class FixClosedBeenadeGroundStoragePlacementPatch
    {
        public static bool Prefix(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
            => itemslot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handling);
    }

    [HarmonyPatch(typeof(ItemTreeSeed), nameof(ItemTreeSeed.OnHeldInteractStart))]
    public static class FixTreeSeedPlacement
    {
        public static bool Prefix(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
            => itemslot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handHandling);
    }

    [HarmonyPatch(typeof(ItemRustyGear), nameof(ItemRustyGear.OnHeldInteractStart))]
    public static class FixRustyGearPlacement
    {
        public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
            => slot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handling);
    }

    [HarmonyPatch(typeof(ItemTemporalGear), nameof(ItemTemporalGear.OnHeldInteractStart))]
    public static class FixTemporalGearPlacement
    {
        public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
            => slot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handHandling);
    }

    [HarmonyPatch(typeof(BlockTorch), nameof(BlockTorch.OnHeldInteractStart))]
    public static class FixTorchPlacement
    {
        public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
            => slot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handling);
    }

    [HarmonyPatch(typeof(Block), nameof(Block.CanPlaceBlock))]
    public static class FixBlockPlacement
    {
        public static bool Prefix(ref bool __result, IWorldAccessor world, IPlayer byPlayer, BlockSelection blockSel, ref string failureCode)
        {
            ItemSlot activeSlot = byPlayer.InventoryManager?.ActiveHotbarSlot;
            EnumHandHandling handHandling = EnumHandHandling.NotHandled;
            bool result = activeSlot.TryFixGroundStoragePlacement(byPlayer.Entity, blockSel, byPlayer.CurrentEntitySelection, true, ref handHandling);
            __result = result;
            return result;
        }
    }
}