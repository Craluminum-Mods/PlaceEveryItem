using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public static class ItemCandle_OnHeldInteractStart_Patch
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ItemCandle), nameof(ItemCandle.OnHeldInteractStart))]
    public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
    {
        return slot.OnHeldInteractStart(byEntity, blockSel, entitySel, firstEvent, ref handHandling);
    }
}
