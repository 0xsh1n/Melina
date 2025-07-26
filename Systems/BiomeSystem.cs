using System;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Melina.Data;
using Melina.Core;
using System.Reflection;
namespace Melina.Systems

{
    public static class BiomeSystem
    {
     
        public static readonly Dictionary<Func<Player, bool>, string> CalamityBiomeDetectors = new();
        public static readonly Dictionary<Func<Player, bool>, string> VanillaBiomeDetectors = new();


        public static bool IsSpecificPylonNearby(Player player, int targetPylonType)
        {
            Point center = player.Center.ToTileCoordinates();
            int range = 40;
            for (int x = center.X - range; x <= center.X + range; x++)
            {
                for (int y = center.Y - range; y <= center.Y + range; y++)
                {
                    if (!WorldGen.InWorld(x, y)) continue;

                    Tile tile = Framing.GetTileSafely(x, y);
                    if (tile.HasTile && tile.TileType == TileID.TeleportationPylon)
                    {
                        int pylonType = tile.TileFrameX / 54;
                        if (pylonType == targetPylonType)
                            return true;
                    }
                }
            }

            return false;
        }

        public static bool IsInFloatingIsland(Player player)
        {
            if (!player.ZoneSkyHeight)
                return false;

            Point center = player.Center.ToTileCoordinates();
            bool hasWater = false;
            int cloudCount = 0;
            int rainCloudCount = 0;

            for (int x = -20; x <= 20; x++)
            {
                for (int y = -20; y <= 20; y++)
                {
                    int i = center.X + x;
                    int j = center.Y + y;
                    if (!WorldGen.InWorld(i, j))
                        continue;

                    Tile tile = Framing.GetTileSafely(i, j);

                    if (tile.LiquidAmount > 0 && tile.LiquidType == 0)
                        hasWater = true;

                    if (tile.HasTile)
                    {
                        if (tile.TileType == TileID.Cloud)
                            cloudCount++;
                        else if (tile.TileType == TileID.RainCloud)
                            rainCloudCount++;
                    }
                }
            }

            return hasWater && cloudCount >= 20 && rainCloudCount >= 20;
        }

        
        public static bool IsFloatingIslandTilesPresent(Player player)
                {
            if (!player.ZoneSkyHeight)
                return false;

            Point center = player.Center.ToTileCoordinates();
            int cloudCount = 0;
            int sunplateCount = 0;
            int totalIslandTiles = 0;

            for (int x = -20; x <= 20; x++)
            {
                for (int y = -20; y <= 20; y++)
                {
                    int i = center.X + x;
                    int j = center.Y + y;
                    if (!WorldGen.InWorld(i, j))
                        continue;

                    Tile tile = Framing.GetTileSafely(i, j);
                    if (!tile.HasTile) continue;

                    if (tile.TileType == TileID.Cloud || tile.TileType == TileID.RainCloud)
                    {
                        cloudCount++;
                        totalIslandTiles++;
                    }
                    else if (tile.TileType == TileID.Sunplate || tile.TileType == TileID.Grass || tile.TileType == TileID.Dirt)
                    {
                        sunplateCount++;
                        totalIslandTiles++;
                    }
                }
            }

            return totalIslandTiles >= 60 && cloudCount >= 30 && sunplateCount >= 10;
        }

        public static bool IsInAether(Player player)
        {
            Point center = player.Center.ToTileCoordinates();
            for (int x = -10; x <= 10; x++)
            {
                for (int y = -10; y <= 10; y++)
                {
                    int i = center.X + x;
                    int j = center.Y + y;
                    if (!WorldGen.InWorld(i, j)) continue;
                    Tile tile = Main.tile[i, j];
                    if (tile != null && tile.LiquidType == 3 && tile.LiquidAmount > 100)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static string GetActiveBiome(Player player)
        {
            foreach (var kvp in CalamityBiomeDetectors)
            {
                if (kvp.Key(player))
                    return kvp.Value;
            }

            foreach (var kvp in VanillaBiomeDetectors)
            {
                if (kvp.Key(player))
                    return kvp.Value;
            }

            return "Unknown";
        }
        public static void TryAddBiomeFromTypeString(string typeFullName, string displayName)
        {
            var type = Reflection.TryGetCalamityType(typeFullName);
            if (type == null) return;

            TryAddBiome(player =>
            {
                var inModBiomeMethod = typeof(Player).GetMethod("InModBiome", new[] { typeof(ModBiome) });
                if (inModBiomeMethod == null) return false;

                var getInstanceMethod = typeof(ModContent)
                    .GetMethod("GetInstance", BindingFlags.Public | BindingFlags.Static)
                    ?.MakeGenericMethod(type);
                if (getInstanceMethod == null) return false;

                var biomeInstance = getInstanceMethod.Invoke(null, null);
                if (biomeInstance == null) return false;

                return (bool)inModBiomeMethod.Invoke(player, new[] { biomeInstance });
            }, displayName, isCalamity: true);
        }

        public static void TryAddBiome(Func<Player, bool> checker, string name, bool isCalamity = false)
        {
            if (isCalamity)
                CalamityBiomeDetectors[checker] = name;
            else
                VanillaBiomeDetectors[checker] = name;
        }

    }
}