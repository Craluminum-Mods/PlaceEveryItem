using Newtonsoft.Json;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public class DataGroundStorable
{
    public bool Enabled { get; set; }
    public bool CtrlKey { get; set; }

    [JsonProperty]
    [JsonConverter(typeof(JsonAttributesConverter))]
    public JsonObject PlaceEveryItemProperties;

    public virtual GroundStoragePropertiesExtended GetProps(EnumGroundStorageLayout forLayout)
    {
        return new GroundStoragePropertiesExtended()
        {
            PlaceEveryItemProperties = PlaceEveryItemProperties,
            Layout = forLayout,
            CtrlKey = CtrlKey,
            SelectionBox = new(0, 0, 0, 1, 0.125f, 1),
            CollisionBox = new(0, 0, 0, 0, 0, 0)
        };
    }
}