using System.Reflection;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;
using Vintagestory.API.MathTools;

namespace PlaceEveryItem;

public class HarmonyPatchesForPei : ModSystem
{
    public const string HarmonyID = "craluminum2413.placeeveryitemonly";

    public override void StartPre(ICoreAPI api)
    {
        base.StartPre(api);
        new Harmony(HarmonyID).PatchAll(Assembly.GetExecutingAssembly());
    }

    public override void Dispose()
    {
        new Harmony(HarmonyID).UnpatchAll();
        base.Dispose();
    }

    [HarmonyPatch]
    public static class Patches
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemDryGrass), nameof(ItemDryGrass.OnHeldInteractStart))]
        public static bool ItemDryGrass_OnHeldInteractStart_Patch(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
        {
            return OnHeldInteractStart(itemslot, byEntity, blockSel, entitySel, firstEvent, ref handHandling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemTreeSeed), nameof(ItemTreeSeed.OnHeldInteractStart))]
        public static bool ItemTreeSeed_OnHeldInteractStart_Patch(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
        {
            return OnHeldInteractStart(itemslot, byEntity, blockSel, entitySel, firstEvent, ref handHandling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemPlantableSeed), nameof(ItemPlantableSeed.OnHeldInteractStart))]
        public static bool ItemPlantableSeed_OnHeldInteractStart_Patch(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
        {
            return OnHeldInteractStart(itemslot, byEntity, blockSel, entitySel, firstEvent, ref handHandling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemFlint), nameof(ItemFlint.OnHeldInteractStart))]
        public static bool ItemFlint_OnHeldInteractStart_Patch(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            return OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemPoultice), nameof(ItemPoultice.OnHeldInteractStart))]
        public static bool ItemPoultice_OnHeldInteractStart_Patch(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            return OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(BlockSupportBeam), nameof(BlockSupportBeam.OnHeldInteractStart))]
        public static bool BlockSupportBeam_OnHeldInteractStart_Patch(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            return OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemCandle), nameof(ItemCandle.OnHeldInteractStart))]
        public static bool ItemCandle_OnHeldInteractStart_Patch(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
        {
            return OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handHandling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemCattailRoot), nameof(ItemCattailRoot.OnHeldInteractStart))]
        public static bool ItemCattailRoot_OnHeldInteractStart_Patch(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
        {
            return OnHeldInteractStart(itemslot, byEntity, blockSel, entitySel, firstEvent, ref handHandling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemClay), nameof(ItemClay.OnHeldInteractStart))]
        public static bool ItemClay_OnHeldInteractStart_Patch(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            return OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemSling), nameof(ItemSling.OnHeldInteractStart))]
        public static bool ItemSling_OnHeldInteractStart_Patch(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            return OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemHoneyComb), nameof(ItemHoneyComb.OnHeldInteractStart))]
        public static bool ItemHoneyComb_OnHeldInteractStart_Patch(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            return OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemTemporalGear), nameof(ItemTemporalGear.OnHeldInteractStart))]
        public static bool ItemTemporalGear_OnHeldInteractStart_Patch(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
        {
            return OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handHandling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemRustyGear), nameof(ItemRustyGear.OnHeldInteractStart))]
        public static bool ItemRustyGear_OnHeldInteractStart_Patch(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            return OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemOpenedBeenade), nameof(ItemOpenedBeenade.OnHeldInteractStart))]
        public static bool ItemOpenedBeenade_OnHeldInteractStart_Patch(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            return OnHeldInteractStart(itemslot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemClosedBeenade), nameof(ItemClosedBeenade.OnHeldInteractStart))]
        public static bool ItemClosedBeenade_OnHeldInteractStart_Patch(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            return OnHeldInteractStart(itemslot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemPileable), nameof(ItemPileable.OnHeldInteractStart))]
        public static bool ItemPileable_OnHeldInteractStart_Patch(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            return OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }

        /// <summary> Place dough on table instead creating pie</summary>
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemDough), nameof(ItemDough.OnHeldInteractStart))]
        public static bool ItemDough_OnHeldInteractStart_Patch(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            return OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }

        private static bool OnHeldInteractStart(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            if (blockSel == null || byEntity == null) return true;

            var bh = slot.Itemstack.Collectible.GetBehavior<CollectibleBehaviorGroundStorable>();
            if (bh == null) return true;

            var isUpFace = blockSel.Face == BlockFacing.UP;
            var isGroundStorage = blockSel.Block is BlockGroundStorage;
            var begs = byEntity.World.BlockAccessor.GetBlockEntity(blockSel.Position) as BlockEntityGroundStorage;

            if (isGroundStorage && begs.CanCreateCharcoalFirepit(slot, blockSel)) return true;

            if ((isGroundStorage && !begs.CanCreatePitKiln()) || isUpFace)
            {
                var ctrlKey = byEntity.Controls.CtrlKey;

                if (bh.StorageProps.SprintKey && !ctrlKey)
                {
                    return true;
                }

                var handHandling = EnumHandling.PassThrough;
                bh.OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling, ref handHandling);
                return false;
            }

            return true;
        }
    }
}