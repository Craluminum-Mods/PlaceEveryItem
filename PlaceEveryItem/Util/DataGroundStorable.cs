using Newtonsoft.Json;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace PlaceEveryItem;

public class DataGroundStorable
{
    [JsonProperty(Order = 1)]
    public bool Enabled { get; set; }

    [JsonProperty(Order = 2)]
    public bool CtrlKey { get; set; }

    [JsonProperty(Order = 3)]
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