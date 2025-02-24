using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public class GroundStoragePropertiesExtended : GroundStorageProperties
{
    [JsonProperty]
    [JsonConverter(typeof(JsonAttributesConverter))]
    public JsonObject PlaceEveryItemProperties;

    public void EnsurePropertiesNotNull()
    {
        PlaceEveryItemProperties ??= new JsonObject(new JObject());
    }

    public new GroundStoragePropertiesExtended Clone()
    {
        return new GroundStoragePropertiesExtended
        {
            PlaceEveryItemProperties = PlaceEveryItemProperties?.Clone(),
            Layout = Layout,
            WallOffY = WallOffY,
            PlaceRemoveSound = PlaceRemoveSound?.Clone(),
            RandomizeSoundPitch = RandomizeSoundPitch,
            StackingCapacity = StackingCapacity,
            StackingModel = StackingModel?.Clone(),
            StackingTextures = StackingTextures?.ToDictionary(x => x.Key, x => x.Value.Clone()),
            MaxStackingHeight = MaxStackingHeight,
            TransferQuantity = TransferQuantity,
            BulkTransferQuantity = BulkTransferQuantity,
            CollisionBox = CollisionBox?.Clone(),
            SelectionBox = SelectionBox?.Clone(),
            CbScaleYByLayer = CbScaleYByLayer,
            MaxFireable = MaxFireable,
            CtrlKey = CtrlKey,
            UpSolid = UpSolid,
            ModelItemsToStackSizeRatio = ModelItemsToStackSizeRatio
        };
    }
}