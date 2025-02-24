using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

[HarmonyPatch(typeof(ItemOpenedBeenade), nameof(ItemOpenedBeenade.OnHeldInteractStart))]
public static class FixOpenedBeenadeGroundStoragePlacementPatch
{
    [HarmonyPrefix]
    public static bool Prefix(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
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

        EnumHandling _handling = EnumHandling.PassThrough;

        behavior.OnHeldInteractStart(itemslot, byEntity, blockSel, null, true, ref handling, ref _handling);

        return false;
    }
}
