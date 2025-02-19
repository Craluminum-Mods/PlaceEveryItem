using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public static class ItemOpenedBeenade_OnHeldInteractStart_Patch
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ItemOpenedBeenade), nameof(ItemOpenedBeenade.OnHeldInteractStart))]
    public static bool Prefix(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
    {
        return itemslot.OnHeldInteractStart(byEntity, blockSel, entitySel, firstEvent, ref handling);
    }
}
