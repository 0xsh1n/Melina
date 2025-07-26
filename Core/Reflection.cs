using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace Melina.Core
{
    public static class Reflection
    {
        public static bool CalamityLoaded => ModLoader.HasMod("CalamityMod");
        private static Mod _calamityMod;
        
        public static Mod GetCalamityMod()
        {
            if (!CalamityLoaded) return null;
            return _calamityMod ??= ModLoader.GetMod("CalamityMod");
        }
        public static bool GetStaticBool(string fullTypeName, string fieldName)
        {
            var type = TryGetCalamityType(fullTypeName);
            if (type == null) return false;

            var field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (field == null || field.FieldType != typeof(bool)) return false;

            return (bool)field.GetValue(null);
        }
        public static bool TryGetCalamityMod(out Mod calamityMod)
        {
            calamityMod = GetCalamityMod();
            return calamityMod != null;
        }

        public static Type TryGetCalamityType(string fullName)
        {
            return TryGetCalamityMod(out var calamityMod) ? calamityMod.Code?.GetType(fullName) : null;
        }
    }
}