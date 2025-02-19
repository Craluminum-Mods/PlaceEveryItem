using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public static class ItemCattailRoot_OnHeldInteractStart_Patch
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ItemCattailRoot), nameof(ItemCattailRoot.OnHeldInteractStart))]
    public static bool Prefix(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
    {
        return itemslot.OnHeldInteractStart(byEntity, blockSel, entitySel, firstEvent, ref handHandling);
    }
}
