using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace PlaceEveryItem;

public static class ModConfig
{
    private const string jsonConfig = "PlaceEveryItemConfig.json";
    private static Config config;
    private static ICoreServerAPI sapi;

    public static Config ReadConfig(ICoreServerAPI api)
    {
        sapi = api;

        try
        {
            config = LoadConfig(api);

            if (config == null)
            {
                GenerateConfig(api);
                config = LoadConfig(api);
            }
            else
            {
                GenerateConfig(api, config);
            }
        }
        catch
        {
            GenerateConfig(api);
            config = LoadConfig(api);
        }

        api.AppendBehaviors(config);

        return config;
    }

    private static Config LoadConfig(ICoreAPI api) => api.LoadModConfig<Config>(jsonConfig);
    private static void GenerateConfig(ICoreAPI api) => api.StoreModConfig(new Config(sapi), jsonConfig);
    private static void GenerateConfig(ICoreAPI api, Config previousConfig) => api.StoreModConfig(new Config(previousConfig), jsonConfig);
}