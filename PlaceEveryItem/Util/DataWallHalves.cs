using Vintagestory.GameContent;

namespace PlaceEveryItem;

public class DataWallHalves : DataGroundStorable
{
    public int WallOffY { get; set; }

    public override GroundStoragePropertiesExtended GetProps(EnumGroundStorageLayout forLayout)
    {
        return new GroundStoragePropertiesExtended()
        {
            PlaceEveryItemProperties = PlaceEveryItemProperties,
            Layout = forLayout,
            CtrlKey = CtrlKey,
            WallOffY = WallOffY,
            SelectionBox = new(0, 0, 0, 1, 0.125f, 1),
            CollisionBox = new(0, 0, 0, 0, 0, 0)
        };
    }
}
