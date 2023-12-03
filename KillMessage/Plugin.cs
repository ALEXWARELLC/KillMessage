using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Features;

namespace KillMessage
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "KillMessages";
        public override string Author => "Cypher The Protogen & TylerTheSCPGuy";
        public override string Prefix => "killmessages";
        public override Version Version => new Version(0, 0, 1);
        public override PluginPriority Priority => PluginPriority.High;

        public override void OnEnabled() => Exiled.Events.Handlers.Player.Died += Died;

        public override void OnDisabled() => Exiled.Events.Handlers.Player.Died -= Died;

        public void Died(DiedEventArgs args)
        {
            if (args.Attacker != null)
            {
                args.Attacker.ShowHint(new Hint($"You killed <color={Config.HighlightColor}>{args.Player.Nickname}</color>"));
                args.Player.ShowHint(new Hint($"You were killed by <color={Config.HighlightColor}>{args.Attacker.Nickname}</color>"));
            }
            else
            {
                args.Player.ShowHint(new Hint($"You were killed by <color={Config.HighlightColor}>an unknown force</color>"));
            }
        }
    }

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public string HighlightColor { get; set; } = "red";
        public string ClassHighlightColor { get; set; } = "blue";
    }
}