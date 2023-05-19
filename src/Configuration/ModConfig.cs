using Vintagestory.API.Common;

namespace PlaceEveryItem.Configuration
{
    static class ModConfig
    {
        private const string jsonConfig = "PlaceEveryItemConfig.json";
        private static PlaceEveryItemConfig config;

        public static void ReadConfig(ICoreAPI api)
        {
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
        }

        private static PlaceEveryItemConfig LoadConfig(ICoreAPI api) => api.LoadModConfig<PlaceEveryItemConfig>(jsonConfig);
        private static void GenerateConfig(ICoreAPI api) => api.StoreModConfig(new PlaceEveryItemConfig(), jsonConfig);
        private static void GenerateConfig(ICoreAPI api, PlaceEveryItemConfig previousConfig) => api.StoreModConfig(new PlaceEveryItemConfig(previousConfig), jsonConfig);
    }
}