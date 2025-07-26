using System;
using Terraria;
using Terraria.ModLoader;
using Melina.Systems;
using Terraria.ID;

namespace Melina.Data
{
    public static class Biome
    {
        public static void InitializeCalamityBiomes(Mod calamity)
        {
        BiomeSystem.TryAddBiomeFromTypeString("CalamityMod.BiomeManagers.SulphurousSeaBiome", "Sulphurous Sea");
        BiomeSystem.TryAddBiomeFromTypeString("CalamityMod.BiomeManagers.BrimstoneCragsBiome", "Brimstone Crags");
        BiomeSystem.TryAddBiomeFromTypeString("CalamityMod.BiomeManagers.SunkenSeaBiome", "Sunken Sea");
        BiomeSystem.TryAddBiomeFromTypeString("CalamityMod.BiomeManagers.AstralInfectionBiome", "Astral Infection");

        BiomeSystem.TryAddBiomeFromTypeString("CalamityMod.BiomeManagers.AbyssLayer1Biome", "Abyss Layer 1");
        BiomeSystem.TryAddBiomeFromTypeString("CalamityMod.BiomeManagers.AbyssLayer2Biome", "Abyss Layer 2");
        BiomeSystem.TryAddBiomeFromTypeString("CalamityMod.BiomeManagers.AbyssLayer3Biome", "Abyss Layer 3");
        BiomeSystem.TryAddBiomeFromTypeString("CalamityMod.BiomeManagers.AbyssLayer4Biome", "Abyss Layer 4");
        }

        public static void InitializeVanillaBiomes()
        {
            BiomeSystem.TryAddBiome(p => p.ZoneCorrupt && p.ZoneDesert && (p.ZoneRockLayerHeight || p.ZoneDirtLayerHeight), "Corrupted Underground Desert");
            BiomeSystem.TryAddBiome(p => p.ZoneCrimson && p.ZoneDesert && (p.ZoneRockLayerHeight || p.ZoneDirtLayerHeight), "Crimson Underground Desert");
            BiomeSystem.TryAddBiome(p => p.ZoneCorrupt && p.ZoneSnow && (p.ZoneRockLayerHeight || p.ZoneDirtLayerHeight), "Corrupted Underground Ice");
            BiomeSystem.TryAddBiome(p => p.ZoneCrimson && p.ZoneSnow && (p.ZoneRockLayerHeight || p.ZoneDirtLayerHeight), "Crimson Underground Ice");
            BiomeSystem.TryAddBiome(p => p.townNPCs > 3f  && BiomeSystem.IsSpecificPylonNearby(p, 0),"Forest Pylon");
            BiomeSystem.TryAddBiome(p => p.townNPCs > 3f && p.ZoneNormalCaverns && BiomeSystem.IsSpecificPylonNearby(p, 1),"Cavern Pylon");
            BiomeSystem.TryAddBiome(p => p.townNPCs > 3f && BiomeSystem.IsSpecificPylonNearby(p, 2),"Jungle Pylon");
            BiomeSystem.TryAddBiome(p => p.townNPCs > 3f && BiomeSystem.IsSpecificPylonNearby(p, 3),"Hallow Pylon");
            BiomeSystem.TryAddBiome(p => p.townNPCs > 3f && BiomeSystem.IsSpecificPylonNearby(p, 4),"Ocean Pylon");
            BiomeSystem.TryAddBiome(p => p.townNPCs > 3f && BiomeSystem.IsSpecificPylonNearby(p, 5),"Desert Pylon");
            BiomeSystem.TryAddBiome(p => p.townNPCs > 3f && BiomeSystem.IsSpecificPylonNearby(p, 6),"Snow Pylon");
            BiomeSystem.TryAddBiome(p => p.townNPCs > 3f && BiomeSystem.IsSpecificPylonNearby(p, 7),"Mushroom Pylon");
            BiomeSystem.TryAddBiome(p => BiomeSystem.IsSpecificPylonNearby(p, 8),"Universal Pylon");
            BiomeSystem.TryAddBiome(BiomeSystem.IsInAether, "Aether");
            BiomeSystem.TryAddBiome(p => p.ZoneHive, "Bee Hive");
            BiomeSystem.TryAddBiome(p => p.ZoneDungeon, "Dungeon");
            BiomeSystem.TryAddBiome(p => p.ZoneGranite, "Granite Cave");
            BiomeSystem.TryAddBiome(p => p.ZoneGraveyard, "Graveyard");
            BiomeSystem.TryAddBiome(p => p.ZoneLihzhardTemple, "Jungle Temple");
            BiomeSystem.TryAddBiome(p => p.ZoneMarble, "Marble Cave");
            BiomeSystem.TryAddBiome(p => p.ZoneMeteor, "Meteorite");

            BiomeSystem.TryAddBiome(BiomeSystem.IsFloatingIslandTilesPresent, "Floating Island");
            BiomeSystem.TryAddBiome(BiomeSystem.IsInFloatingIsland, "Floating Lake");

            BiomeSystem.TryAddBiome(p => p.ZoneHallow && p.ZoneSnow, "Hallowed Ice");
            BiomeSystem.TryAddBiome(p => p.ZoneCrimson && p.ZoneSnow, "Crimson Ice");
            BiomeSystem.TryAddBiome(p => p.ZoneCorrupt && p.ZoneSnow, "Corrupted Ice");

            BiomeSystem.TryAddBiome(p => p.ZoneHallow && p.ZoneDesert, "Hallowed Desert");
            BiomeSystem.TryAddBiome(p => p.ZoneCrimson && p.ZoneDesert, "Crimson Desert");
            BiomeSystem.TryAddBiome(p => p.ZoneCorrupt && p.ZoneDesert, "Corrupted Desert");

            BiomeSystem.TryAddBiome(p => p.ZoneSnow && (p.ZoneRockLayerHeight || p.ZoneDirtLayerHeight), "Underground Ice");
            BiomeSystem.TryAddBiome(p => p.ZoneDesert && (p.ZoneRockLayerHeight || p.ZoneDirtLayerHeight), "Underground Desert");
            BiomeSystem.TryAddBiome(p => p.ZoneGlowshroom && (p.ZoneRockLayerHeight || p.ZoneDirtLayerHeight), "Underground Glowing Mushroom");
            BiomeSystem.TryAddBiome(p => p.ZoneHallow && (p.ZoneRockLayerHeight || p.ZoneDirtLayerHeight), "Underground Hallow");
            BiomeSystem.TryAddBiome(p => p.ZoneCrimson && (p.ZoneRockLayerHeight || p.ZoneDirtLayerHeight), "Underground Crimson");
            BiomeSystem.TryAddBiome(p => p.ZoneCorrupt && (p.ZoneRockLayerHeight || p.ZoneDirtLayerHeight), "Underground Corruption");
            BiomeSystem.TryAddBiome(p => p.ZoneJungle && (p.ZoneRockLayerHeight || p.ZoneDirtLayerHeight), "Underground Jungle");
            BiomeSystem.TryAddBiome(p => p.ZoneGlowshroom, "Glowing Mushroom");
            BiomeSystem.TryAddBiome(p => p.ZoneSkyHeight, "Space");
            BiomeSystem.TryAddBiome(p => p.ZoneForest, "Forest");
            BiomeSystem.TryAddBiome(p => p.ZoneJungle, "Jungle");
            BiomeSystem.TryAddBiome(p => p.ZoneSnow, "Snow");
            BiomeSystem.TryAddBiome(p => p.ZoneCorrupt, "The Corruption");
            BiomeSystem.TryAddBiome(p => p.ZoneCrimson, "The Crimson");
            BiomeSystem.TryAddBiome(p => p.ZoneHallow, "The Hallow");
            BiomeSystem.TryAddBiome(p => p.ZoneDesert, "Desert");
            BiomeSystem.TryAddBiome(p => p.ZoneBeach, "Ocean");
            BiomeSystem.TryAddBiome(p => p.ZoneNormalCaverns, "Cavern");
            BiomeSystem.TryAddBiome(p => p.ZoneNormalUnderground, "Underground");
            BiomeSystem.TryAddBiome(p => p.ZoneUnderworldHeight, "The Underworld");

        }
    }
}