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

    public static void AppendBehavior(this CollectibleObject collobj, object objectProperties)
    {
        CollectibleBehaviorGroundStorable instance = new CollectibleBehaviorGroundStorable(collobj);
        instance.Initialize(new JsonObject(JToken.FromObject(objectProperties)));
        collobj.CollectibleBehaviors = collobj.CollectibleBehaviors.Append(instance);
    }

    public static bool IsGroundStorable(this CollectibleObject obj) => obj.HasBehavior<CollectibleBehaviorGroundStorable>();

    public static void ApplyTransform(this CollectibleObject obj, ModelTransform transform)
    {
        obj.Attributes ??= new JsonObject(new JObject());
        obj.Attributes.Token[TransformAttributeName] = JToken.FromObject(transform);
    }

    public static void AddToCreativeInventory(this CollectibleObject obj)
    {
        if (obj.CreativeInventoryStacks != null)
        {
            for (int i = 0; i < obj.CreativeInventoryStacks.Length; i++)
            {
                if (obj.CreativeInventoryStacks[i].Tabs.Contains("groundstorable"))
                {
                    continue;
                }
                obj.CreativeInventoryStacks[i].Tabs = obj.CreativeInventoryStacks[i].Tabs.Append("groundstorable");
            }
            return;
        }
        if (obj.CreativeInventoryTabs != null && !obj.CreativeInventoryTabs.Contains("groundstorable"))
        {
            obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
        }
    }
}