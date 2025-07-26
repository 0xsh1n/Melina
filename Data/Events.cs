using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using Melina.Systems;
namespace Melina.Data
{
    public static class Events
    {
        public static void InitializeCalamityEvents(Mod calamity)
        {
            EventSystem.TryAddEventFlag("CalamityMod.Events.BossRushEvent", "BossRushActive", "Boss Rush");

            EventSystem.TryAddEventFlag(
                "CalamityMod.Events.AcidRainEvent",
                "AcidRainEventIsOngoing",
                "Acid Rain",
                p => p.ZoneOverworldHeight
            );

        }

        public static void InitializeVanillaEvents()
        {
            EventSystem.TryAddEvent(p => p.ZoneOverworldHeight && Main.invasionType == 1 && Main.invasionSize > 0, "Goblin Army");
            EventSystem.TryAddEvent(p => p.ZoneOverworldHeight && Main.invasionType == 2 && Main.invasionSize > 0, "Frost Legion");
            EventSystem.TryAddEvent(p => p.ZoneOverworldHeight && Main.invasionType == 4 && Main.invasionSize > 0, "Martian Madness");
            EventSystem.TryAddEvent(p => p.ZoneOverworldHeight && Main.invasionType == 3 && Main.invasionSize > 0, "Pirate Invasion");

            EventSystem.TryAddEvent(p => DD2Event.Ongoing && p.ZoneOldOneArmy, "Old One's Army");

            EventSystem.TryAddEvent(p => p.ZoneTowerSolar && p.ZoneOverworldHeight, "Solar Pillar");
            EventSystem.TryAddEvent(p => p.ZoneTowerVortex && p.ZoneOverworldHeight, "Vortex Pillar");
            EventSystem.TryAddEvent(p => p.ZoneTowerNebula && p.ZoneOverworldHeight, "Nebula Pillar");
            EventSystem.TryAddEvent(p => p.ZoneTowerStardust && p.ZoneOverworldHeight, "Stardust Pillar");

            EventSystem.TryAddEvent(p => Main.snowMoon && p.ZoneOverworldHeight && !Main.dayTime, "Frost Moon");
            EventSystem.TryAddEvent(p => Main.eclipse && p.ZoneOverworldHeight && Main.dayTime, "Solar Eclipse");
            EventSystem.TryAddEvent(p => Main.pumpkinMoon && p.ZoneOverworldHeight && !Main.dayTime, "Pumpkin Moon");
            EventSystem.TryAddEvent(p => Main.slimeRain && p.ZoneOverworldHeight, "Slime Rain");
            EventSystem.TryAddEvent(p => Main.bloodMoon && p.ZoneOverworldHeight && !Main.dayTime, "Blood Moon");
            EventSystem.TryAddEvent(p => Sandstorm.Happening && p.ZoneDesert && p.ZoneOverworldHeight, "Sandstorm");
            EventSystem.TryAddEvent(p => LanternNight.LanternsUp && p.ZoneOverworldHeight, "Lantern Night");
        }
    }
}

