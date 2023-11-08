using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public static class ItemDryGrass_OnHeldInteractStart_Patch
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ItemDryGrass), nameof(ItemDryGrass.OnHeldInteractStart))]
    public static bool Prefix(ItemSlot itemslot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
    {
        return itemslot.OnHeldInteractStart(byEntity, blockSel, entitySel, firstEvent, ref handHandling);
    }
}
