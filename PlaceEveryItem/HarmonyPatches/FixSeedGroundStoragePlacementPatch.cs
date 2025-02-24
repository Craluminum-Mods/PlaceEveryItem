using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

[HarmonyPatch(typeof(ItemPlantableSeed), nameof(ItemPlantableSeed.OnHeldInteractStart))]
public static class FixSeedGroundStoragePlacementPatch
{
    [HarmonyPrefix]
    public static bool Prefix(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
    {
        if (blockSel == null || byEntity == null)
        {
            return true;
        }

        bool pressedCtrlKey = byEntity.Controls.CtrlKey;
        CollectibleBehaviorGroundStorable behavior = byEntity.ActiveHandItemSlot?.GetGroundStorableBehavior();
        bool requiresCtrlKey = behavior?.StorageProps.CtrlKey == true;

        if (behavior == null || !behavior.CanFixPlacement() || (requiresCtrlKey && !pressedCtrlKey))
        {
            return true;
        }

        EnumHandling handling = EnumHandling.PassThrough;

        behavior.OnHeldInteractStart(itemslot, byEntity, blockSel, null, true, ref handHandling, ref handling);

        return false;
    }
}