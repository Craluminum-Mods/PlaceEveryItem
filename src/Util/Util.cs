using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

namespace PlaceEveryItem
{
    public static class Util
    {
        public const string AttributeName = "groundStorageTransform";

        public static void AppendBehavior(this CollectibleObject collobj, object objectProperties)
        {
            var instance = new CollectibleBehaviorGroundStorable(collobj);
            instance.Initialize(new JsonObject(JToken.FromObject(objectProperties)));
            collobj.CollectibleBehaviors = collobj.CollectibleBehaviors.Append(instance);
        }

        public static bool IsGroundStorable(this CollectibleObject obj) => obj.HasBehavior<CollectibleBehaviorGroundStorable>();

        public static bool IsMatched(this CollectibleObject obj, string key) => !string.IsNullOrEmpty(key) && obj.WildcardRegexMatch(key);

        public static bool WildcardRegexMatch(this CollectibleObject obj, string key) => WildcardUtil.Match(new AssetLocation(key), obj.Code);

        public static void ApplyCreativeInventoryTab(this CollectibleObject obj)
        {
            var isFruiTtree = obj.WildcardRegexMatch("fruittree-*");
            if (!isFruiTtree && obj.CreativeInventoryTabs != null && obj.CreativeInventoryTabs.Length != 0 && !string.IsNullOrEmpty(obj?.CreativeInventoryTabs?[0]))
            {
                obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
            }

            if (isFruiTtree && obj.CreativeInventoryStacks != null)
            {
                for (int i = 0; i < obj.CreativeInventoryStacks.Length; i++)
                {
                    obj.CreativeInventoryStacks[i].Tabs = obj.CreativeInventoryStacks[i].Tabs.Append("groundstorable");
                }
            }
        }

        public static void ApplyTransforms(this CollectibleObject obj, Dictionary<string, ModelTransform> transformations)
        {
            foreach (var item in transformations)
            {
                if (obj.WildcardRegexMatch(item.Key))
                {
                    obj.ApplyTransform(item.Value);
                }
            }
        }

        public static void ApplyTransform(this CollectibleObject obj, ModelTransform tf)
        {
            obj.Attributes ??= new JsonObject(new JObject());
            obj.Attributes.Token[AttributeName] = JToken.FromObject(tf.EnsureDefaultValues());
        }

        public static void ApplyBlockTransform(this Block block)
        {
            var tf = new ModelTransform();
            tf.Origin.X = 0.5f;
            tf.Origin.Y = 0f;
            tf.Origin.Z = 0.5f;
            tf.Scale = 0.4f;
            ApplyTransform(block, tf);
        }

        public static GroundStorageProperties GetProps(this EnumGroundStorageLayout layout, DataWallHalves val = null)
        {
            return new()
            {
                Layout = layout,
                SprintKey = val?.SprintKey ?? default,
                WallOffY = val?.WallOffY ?? default,
                SelectionBox = new(0, 0, 0, 1, 0.125f, 1),
                CollisionBox = new(0, 0, 0, 0, 0, 0)
            };
        }
    }
}