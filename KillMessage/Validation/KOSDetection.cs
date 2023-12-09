using Exiled.API.Features;
using KillMessage.Features;
using System;

namespace KillMessage.Validation
{
    internal class KOSDetection
    {
        Config Config;

        public KOSDetection(Config ImportedConfig)
        {
            Config = ImportedConfig;
        }

        public bool IsPlayerKOS(Player Target, Player Attacker)
        {
            if (Config == null)
                return false;

            if (Target.IsCuffed)
            {
                AdminChatInterface.LogToAdminChat($"[KOS]: {Attacker.Nickname}({Attacker.Id}) KOS'd {Target.Nickname}({Target.Id})");
                
                if (Config.AlertPlayerOfKOS)
                    Attacker.Broadcast(5, $"You KOS'd {Target.Nickname}. Please don't do that again.");
                return true;
            }

            return false;
        }
    }
}
