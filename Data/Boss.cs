using Terraria.ModLoader;
using Melina.Systems;
using Terraria.ID;

namespace Melina.Data
{
    public static class Boss
    {
        public static void InitializeVanillaBosses()
        {
            BossSystem.BossNameGroups[new() { NPCID.Retinazer, NPCID.Spazmatism }] = "The Twins";
            BossSystem.BossNameGroups[new() { NPCID.MoonLordHead, NPCID.MoonLordHand, NPCID.MoonLordCore }] = "Moon Lord";
        }
        
        
        public static void InitializeCalamityBosses(Mod calamity)
        {
            BossSystem.TryAddBoss(calamity, new[] {
                "Artemis",
                "Apollo",
                "AresBody",
                "ThanatosHead"
            }, "Exo Mechs");       
            BossSystem.TryAddBoss(calamity, new[] {"Anahita","Leviathan"}, "Leviathan and Anahita");

            BossSystem.TryAddBoss(calamity, new[] {
                "ProfanedGuardianCommander",
                "ProfanedGuardianDefender",
                "ProfanedGuardianHealer"
            }, "Profaned Guardians");
        }
    }
}