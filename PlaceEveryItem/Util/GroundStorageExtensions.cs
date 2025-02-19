using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public static class GroundStorageExtensions
{
    //public static bool CanCreatePitKiln(this BlockEntityGroundStorage begs) => begs?.OnTryCreateKiln() != false;

    //public static bool CanCreateCharcoalFirepit(this BlockEntityGroundStorage begs, ItemSlot slot, BlockSelection blockSel)
    //{
    //    return blockSel.Face == BlockFacing.UP && slot.Itemstack.Collectible is ItemDryGrass
    //                    && begs?.Inventory[3]?.Empty == true
    //                    && begs?.Inventory[2]?.Empty == true
    //                    && begs?.Inventory[1]?.Empty == true
    //                    && begs?.Inventory[0]?.Itemstack?.Collectible is ItemFirewood;
    //}

    //public static bool OnHeldInteractStart(this ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
    //{
    //    if (blockSel == null || byEntity == null) return true;

    //    var bh = slot.Itemstack.Collectible.GetBehavior<CollectibleBehaviorGroundStorable>();
    //    if (bh == null) return true;

    //    var isUpFace = blockSel.Face == BlockFacing.UP;
    //    var isGroundStorage = blockSel.Block is BlockGroundStorage;
    //    var begs = byEntity.World.BlockAccessor.GetBlockEntity(blockSel.Position) as BlockEntityGroundStorage;

    //    if (isGroundStorage && begs.CanCreateCharcoalFirepit(slot, blockSel)) return true;

    //    if ((isGroundStorage && !begs.CanCreatePitKiln()) || isUpFace)
    //    {
    //        var ctrlKey = byEntity.Controls.CtrlKey;

    //        if (bh.StorageProps.SprintKey && !ctrlKey)
    //        {
    //            return true;
    //        }

    //        var handHandling = EnumHandling.PassThrough;
    //        bh.OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling, ref handHandling);
    //        return false;
    //    }

    //    return true;
    //}
}