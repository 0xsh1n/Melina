using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Melina.Systems;
using System.Reflection;
namespace Melina.Core
{
    public class InfoSystem : ModSystem
    {

        public override void OnWorldUnload()
        {
            DiscordController.UpdatePresence("In Main Menu", "");
        }
        public override void PostUpdateEverything()
        {
            Player player = Main.LocalPlayer;
            if (player.active)
            {
                string world = Main.worldName;
                string diff = GetCurrentDifficulty();
                string currentEvent = EventSystem.GetCurrentEvent(player);
                string biome = BiomeSystem.GetActiveBiome(player);
                NPC boss = BossSystem.GetActiveBoss();

                string label = boss != null ? $"Fighting {BossSystem.GetBossName(boss.type)}"
                                : !string.IsNullOrEmpty(currentEvent) ? $"In Event {currentEvent}"
                                : $"In {biome}";

                DiscordController.UpdatePresence(label, $"{world} - {diff}");
            }
        
        }

        private string GetCurrentDifficulty()
        {
            string vanillaDifficulty = Main.GameMode == GameModeID.Creative ? "Journey"
                                    : Main.masterMode ? "Master"
                                    : Main.expertMode ? "Expert"
                                    : "Classic";

            string calamityPrefix = null;

            if (Reflection.GetStaticBool("CalamityMod.World.CalamityWorld", "death"))
                calamityPrefix = "Death";
            else if (Reflection.GetStaticBool("CalamityMod.World.CalamityWorld", "revenge"))
                calamityPrefix = "Revengeance";

            return calamityPrefix != null ? $"{calamityPrefix} ({vanillaDifficulty})" : vanillaDifficulty;
        }
    }
}
