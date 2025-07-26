using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using Melina.Data;
using Melina.Core;
namespace Melina.Systems
{

    
    public static class BossSystem
    {
        public static Dictionary<HashSet<int>, string> BossNameGroups = new();
        public static string GetBossName(int npcID)
        {
            foreach (var kvp in BossNameGroups)
            {
                if (kvp.Key.Contains(npcID))
                    return kvp.Value;
            }

            return Lang.GetNPCNameValue(npcID);
        }

        public static NPC GetActiveBoss()
        {
            foreach (NPC npc in Main.npc)
            {
                if (npc != null && npc.active && npc.boss && !string.IsNullOrEmpty(npc.TypeName))
                {
                    ModNPC modNPC = npc.ModNPC;
                    if (modNPC == null || modNPC.Mod?.Name == "CalamityMod")
                        return npc;
                }
            }
            return null;
        }

        public static void TryAddBoss(Mod mod, string npcName, string bossName)
        {
            if (mod.TryFind(npcName, out ModNPC npc))
            {
                BossNameGroups[new() { npc.Type }] = bossName;
            }
        }
        public static void TryAddBoss(Mod mod, string[] npcNames, string bossName)
        {
            HashSet<int> ids = new();
            foreach (string name in npcNames)
            {
                if (mod.TryFind(name, out ModNPC npc))
                    ids.Add(npc.Type);
            }
            if (ids.Count > 0)
                BossNameGroups[ids] = bossName;
        }

    }
}