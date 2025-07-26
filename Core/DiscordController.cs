using DiscordRPC;
using DiscordRPC.Logging;
using Terraria.ModLoader;

namespace Melina.Core
{
    public static class DiscordController
    {
        public static DiscordRpcClient Client { get; private set; }
        private static string _imageKey;
        private static string _imageText;

        public static void Initialize()
        {
            bool calamityLoaded = Reflection.CalamityLoaded;

            string appId = calamityLoaded
                ? "1389387813824233563"  
                : "1391572186828898374"; 

            _imageKey = calamityLoaded
                ? "calamityy"           
                : "terraria";            

            _imageText = calamityLoaded
                ? "Terraria: Calamity"
                : "Terraria (Vanilla)";

            Client = new DiscordRpcClient(appId)
            {
                Logger = new ConsoleLogger { Level = LogLevel.Warning }
            };
            Client.Initialize();
        }

        public static void UpdatePresence(string details, string state)
        {
            Client?.SetPresence(new RichPresence
            {
                Details = details,
                State = state,
                Assets = new Assets
                {
                    LargeImageKey = _imageKey,
                    LargeImageText = _imageText
                }
            });
        }

        public static void Shutdown()
        {
            Client?.Dispose();
        }
    }
}
