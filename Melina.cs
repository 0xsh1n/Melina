using Terraria.ModLoader;
using Melina.Systems;
using Melina.Data;
using Melina.Core;
using Terraria;
using Microsoft.Xna.Framework;

namespace Melina
{
    public class Melina : Mod
    {   
        public override void Load()
        {
            DiscordController.Initialize();
            Events.InitializeVanillaEvents();
            Biome.InitializeVanillaBiomes();
            Boss.InitializeVanillaBosses();

            if (Reflection.TryGetCalamityMod(out var calamityMod))
            {
                Biome.InitializeCalamityBiomes(calamityMod);
                Boss.InitializeCalamityBosses(calamityMod);
                Events.InitializeCalamityEvents(calamityMod);
            }
            if (Main.dedServ)
                return;       
            if (Main.gameMenu && !Main.dedServ)     
                DiscordController.UpdatePresence("In Main Menu", "");
        }

        public override void Unload()
        {
            DiscordController.Shutdown();
            BossSystem.BossNameGroups.Clear();
            EventSystem.CalamityEventDetectors.Clear();
            EventSystem.VanillaEventDetectors.Clear();
            BiomeSystem.VanillaBiomeDetectors.Clear();
            BiomeSystem.CalamityBiomeDetectors.Clear();


        }
    }
}