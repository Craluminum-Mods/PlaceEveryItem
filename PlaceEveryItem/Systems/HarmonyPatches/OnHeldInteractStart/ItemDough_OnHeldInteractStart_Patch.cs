using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

/// <summary> Place dough on table instead creating pie</summary>
public static class ItemDough_OnHeldInteractStart_Patch
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ItemDough), nameof(ItemDough.OnHeldInteractStart))]
    public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
    {
        return slot.OnHeldInteractStart(byEntity, blockSel, entitySel, firstEvent, ref handling);
    }
}
