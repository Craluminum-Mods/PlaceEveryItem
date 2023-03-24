using System.Collections.Generic;

namespace PlaceEveryItem.Configuration
{
    public class PlaceEveryItemConfig
    {
        public bool AllBlocks = true;

        public Dictionary<string, bool> SingleCenter = new()
        {
            { "armor-*", true },
            { "clothes-lowerbody-*", true },
            { "clothes-upperbody-*", true },
            { "clothes-upperbodyover-*", true },
            { "tonwexp:armor-*", true },
            { "hideandfabric:cottonarmor-*", true },
            { "hideandfabric:woolarmor-*", true },
            { "hideandfabric:hidearmor-*", true },
            { "hideandfabric:hide-*", true },
            { "hideandfabric:hidecap-*", true },
            { "hideandfabric:clothes-upperbody-*", true },
            { "hideandfabric:clothes-lowerbody-*", true },
            { "moreclasses:clothes-upperbody-*", true },
            { "moreclasses:clothes-lowerbody-*", true },
        };

        public Dictionary<string, bool> Halves = new()
        {
        };

        public Dictionary<string, DataWallHalves> WallHalves = new()
        {
            { "bowstave-*", new() { Enabled = true, SprintKey = true, WallOffY = 2 } },
            { "helvehammer-*", new() { Enabled = true, SprintKey = true, WallOffY = 3 } },
            { "largegearsection-*", new() { Enabled = true, SprintKey = true, WallOffY = 1 } },
            { "pounder-*", new() { Enabled = true, SprintKey = true, WallOffY = 3 } },
            { "pulverizertoggle-*", new() { Enabled = true, SprintKey = true, WallOffY = 1 } },
        };

        public Dictionary<string, bool> Quadrants = new()
        {
            { "bread-*", true },
            { "bushmeat-*", true },
            { "dough-*", true },
            { "egg-chicken-raw", true },
            { "flour-*", true },
            { "fruit-*", true },
            { "grain-*", true },
            { "insect-*", true },
            { "legume-*", true },
            { "pickled*", true },
            { "poultry-*", true },
            { "pressedmash-*", true },
            { "rawcassava-*", true },
            { "redmeat-*", true },
            { "vegetable-*", true },

            { "arrow-*", true },
            { "arrowhead-*", true },
            { "axehead-*", true },
            { "bladehead-*", true },
            { "hammerhead-*", true },
            { "helvehammerhead-*", true },
            { "hoehead-*", true },
            { "knifeblade-*", true },
            { "pickaxehead-*", true },
            { "prospectingpickhead-*", true },
            { "sawblade-*", true },
            { "scythehead-*", true },
            { "shovelhead-*", true },
            { "spearhead-*", true },

            { "amethyst", true },
            { "angledgears-s", true },
            { "bamboostakes", true },
            { "bandage-*", true },
            { "beenade-*", true },
            { "beeswax", true },
            { "bone", true },
            { "candle", true },
            { "cattailroot", true },
            { "cattailtops", true },
            { "chutesection-*", true },
            { "clearquartz", true },
            { "cloth-*", true },
            { "crystalizedore-*", true },
            { "drygrass", true },
            { "fat", true },
            { "feather", true },
            { "flaxfibers", true },
            { "flaxtwine", true },
            { "flowerpot-*", true },
            { "fruittree-*", true },
            { "gear-rusty", true },
            { "gear-temporal", true },
            { "gem-*", true },
            { "hide-*", true },
            { "honeycomb", true },
            { "ironbloom", true },
            { "leather-*", true },
            { "metal-parts", true },
            { "metal-scraps", true },
            { "metalbit-*", true },
            { "metalchain-*", true },
            { "metallamellae-*", true },
            { "metalscale-*", true },
            { "nugget-*", true },
            { "oillamp-up", true },
            { "ore-*-*", true },
            { "oreblastingbomb", true },
            { "padlock-*", true },
            { "papyrusroot", true },
            { "papyrustops", true },
            { "poultice-*", true },
            { "resin", true },
            { "rosequartz", true },
            { "rot", true },
            { "sail", true },
            { "seashell-*", true },
            { "seeds-*", true },
            { "sewingkit", true },
            { "smokyquartz", true },
            { "solderbar-*", true },
            { "stick", true },
            { "torchholder-*", true },
            { "treeseed-*", true },
            { "tuningcylinder-*", true },
            { "woodenaxle-ud", true },

            { "clothes-arm-*", true },
            { "clothes-emblem-*", true },
            { "clothes-face-*", true },
            { "clothes-hand-*", true },
            { "clothes-head-*", true },
            { "clothes-neck-*", true },
            { "clothes-shoulder-*", true },
            { "clothes-waist-*", true },

            { "acorns:acorn", true },
            { "acorns:acorns-*", true },
            { "acorns:mallet-head", true },
            { "bettercrates:upgrade-*", true },
            { "blacksmiths:spring-*", true },
            { "captureanimals:cage-*", true },
            { "theneighbours:ampeltail", true },
            { "theneighbours:browerskin", true },
            { "theneighbours:turtle_meat-*", true },
            { "bth:choppedwood", true },
            { "lazytweaks:cookedegg", true },
            { "lazytweaks:ash", true },
            { "lazytweaks:causticpotash", true },
            { "lazytweaks:compost-*", true },
            { "lazytweaks:compoundfertilizer", true },
            { "lazytweaks:hidepiece-*", true },
            { "lazytweaks:hide-*", true },
            { "lazytweaks:powderedcharcoal", true },
            { "lazytweaks:straw", true },
            { "necessaries:mailflag", true },
            { "necessaries:glue", true },
            { "necessaries:gluten", true },
            { "necessaries:grounddiamond", true },
            { "necessaries:regscroll", true },
            { "necessaries:sharpener_disc-*", true },
            { "necessaries:sharpener-*", true },
            { "necessaries:sulfurpeter", true },
            { "tprunes:rune_stone_raw_core", true },
            { "tprunes:rune_stone_nest-*", true },
            { "tprunes:raw_rune_stone-*", true },
            { "tprunes:rune_stone-*", true },
            { "primitivesurvival:fishinghook-bone", true },
            { "primitivesurvival:caviar-*", true },
            { "primitivesurvival:cordage", true },
            { "primitivesurvival:fisheggscooked", true },
            { "primitivesurvival:fishfillet-*", true },
            { "primitivesurvival:fishinghook-*", true },
            { "primitivesurvival:fishinglure-*", true },
            { "primitivesurvival:metalfishinghook-*", true },
            { "primitivesurvival:psfish-*", true },
            { "primitivesurvival:crabmeat-*", true },
            { "primitivesurvival:buckethandle-*", true },
            { "primitivesurvival:psgear-*", true },
            { "primitivesurvival:earthwormcastings", true },
            { "primitivesurvival:monkeybridge", true },
            { "primitivesurvival:linktool", true },
            { "primitivesurvival:grunter", true },
            { "primitivesurvival:fuse-*", true },
            { "primitivesurvival:trussedrot", true },
            { "primitivesurvival:smokedmeat-*", true },
            { "primitivesurvival:trussedmeat-*", true },
            { "primitivesurvival:snakemeat-*", true },
            { "primitivesurvival:jerky-bushmeat-*", true },
            { "primitivesurvival:jerky-fish-*", true },
            { "primitivesurvival:jerky-redmeat-*", true },
            { "locustmod:batteryhull", true },
            { "locustmod:brokenhaft", true },
            { "locustmod:bulb", true },
            { "locustmod:coil", true },
            { "locustmod:czbatt", true },
            { "locustmod:drilltip", true },
            { "locustmod:fieldresonator", true },
            { "locustmod:filament", true },
            { "locustmod:metalhaft", true },
            { "locustmod:advparts", true },
            { "locustmod:gloveframe", true },
            { "locustmod:motor", true },
            { "locustmod:schematic-*", true },
            { "locustmod:zincrods", true },
            { "locustmod:temporalessence", true },
            { "locustmod:temporalpowercell", true },
            { "locustmod:temporalpowercore", true },
            { "hideandfabric:cloth-*", true },
            { "hideandfabric:seeds-*", true },
            { "hideandfabric:twine-*", true },
            { "hideandfabric:fibers-*", true },
            { "hideandfabric:poultice-*", true },
            { "hideandfabric:clothes-hand-*", true },
            { "moreclasses:clothes-face-*", true },
            { "moreclasses:clothes-head-*", true },
        };

        public PlaceEveryItemConfig() { }

        public PlaceEveryItemConfig(PlaceEveryItemConfig previousConfig)
        {
            AllBlocks = previousConfig.AllBlocks;

            foreach (var item in previousConfig.SingleCenter)
            {
                if (!SingleCenter.ContainsKey(item.Key))
                {
                    SingleCenter.Add(item.Key, item.Value);
                }
            }

            foreach (var item in previousConfig.Halves)
            {
                if (!Halves.ContainsKey(item.Key))
                {
                    Halves.Add(item.Key, item.Value);
                }
            }

            foreach (var item in previousConfig.WallHalves)
            {
                if (!WallHalves.ContainsKey(item.Key))
                {
                    WallHalves.Add(item.Key, item.Value);
                }
            }

            foreach (var item in previousConfig.Quadrants)
            {
                if (!Quadrants.ContainsKey(item.Key))
                {
                    Quadrants.Add(item.Key, item.Value);
                }
            }
        }
    }
}