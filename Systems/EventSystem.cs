using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.ID;
using Melina.Data;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Melina.Core;
using System;

using System.Reflection;

namespace Melina.Systems
{
    public static class EventSystem
    {
        public static readonly Dictionary<Func<Player, bool>, string> CalamityEventDetectors = new();
        public static readonly Dictionary<Func<Player, bool>, string> VanillaEventDetectors = new();
        public static void TryAddEventFlag(string typeFullName, string fieldName, string displayName, Func<Player, bool> extraCondition = null)
        {
            TryAddEvent(
                player => Reflection.GetStaticBool(typeFullName, fieldName) &&
                        (extraCondition?.Invoke(player) ?? true),
                displayName,
                isCalamity: true
            );
        }
        public static void TryAddEvent(Func<Player, bool> checker, string name, bool isCalamity = false)
        {
            if (isCalamity)
                CalamityEventDetectors[checker] = name;
            else
                VanillaEventDetectors[checker] = name;
        }

        public static string GetCurrentEvent(Player player)
        {
            foreach (var kv in EventSystem.CalamityEventDetectors)
                if (kv.Key(player)) return kv.Value;

            foreach (var kv in EventSystem.VanillaEventDetectors)
                if (kv.Key(player)) return kv.Value;

            return null;
        }
    
    }
}