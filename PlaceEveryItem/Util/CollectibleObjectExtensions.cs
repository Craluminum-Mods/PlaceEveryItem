using Newtonsoft.Json.Linq;
using System.Linq;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public static class CollectibleObjectExtensions
{
    public const string TransformAttributeName = "groundStorageTransform";

    public static JsonObject GetProperties(this CollectibleBehavior behavior)
    {
        return new JsonObject(JToken.Parse(behavior.propertiesAtString));
    }

    public static bool CanFixPlacement(this CollectibleBehaviorGroundStorable behavior)
    {
        return behavior.GetProperties()?["PlaceEveryItemProperties"]?.IsTrue("FixPlacement") == true;
    }

    public static void AppendBehavior(this CollectibleObject collobj, object objectProperties)
    {
        CollectibleBehaviorGroundStorable instance = new CollectibleBehaviorGroundStorable(collobj);
        instance.Initialize(new JsonObject(JToken.FromObject(objectProperties)));
        collobj.CollectibleBehaviors = collobj.CollectibleBehaviors.Append(instance);
    }

    public static bool IsGroundStorable(this CollectibleObject obj)
    {
        return obj.HasBehavior<CollectibleBehaviorGroundStorable>();
    }

    public static CollectibleBehaviorGroundStorable GetGroundStorableBehavior(this ItemSlot slot)
    {
        return slot?.Itemstack?.Collectible?.GetBehavior<CollectibleBehaviorGroundStorable>();
    }

    public static void ApplyTransform(this CollectibleObject obj, ModelTransform transform)
    {
        obj.Attributes ??= new JsonObject(new JObject());
        obj.Attributes.Token[TransformAttributeName] = JToken.FromObject(transform);
    }

    public static void AddToCreativeInventory(this CollectibleObject obj)
    {
        if (obj.CreativeInventoryTabs?.Length > 0 && !obj.CreativeInventoryTabs.Contains("groundstorable"))
        {
            obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
            return;
        }
        if (obj.CreativeInventoryStacks?.Length > 0)
        {
            for (int i = 0; i < obj.CreativeInventoryStacks.Length; i++)
            {
                if (obj.CreativeInventoryStacks[i].Tabs.Contains("groundstorable"))
                {
                    continue;
                }
                obj.CreativeInventoryStacks[i].Tabs = obj.CreativeInventoryStacks[i].Tabs.Append("groundstorable");
            }
        }
    }

    public static bool TryFixGroundStoragePlacement(this ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
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

        behavior.OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handHandling, ref _handling);

        return false;
    }
}