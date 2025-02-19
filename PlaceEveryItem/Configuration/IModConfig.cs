using Vintagestory.API.Common;

namespace PlaceEveryItem.Configuration;

public interface IModConfig
{
    public bool AutoFill { get; set; }
    public void FillDefault(ICoreAPI api);
}