using Exiled.API.Features;
using System;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace TeamGenocide
{
    public class Plugin : Plugin<Config>
    {
        private EventHandler events;
        public static Plugin Instance;

        public override string Name => "TeamGenocide";
        public override string Author => "Heisenberg3666";
        public override Version Version => new Version(1, 1, 1, 0);
        public override Version RequiredExiledVersion => new Version(5, 1, 3);

        public override void OnEnabled()
        {
            Instance = this;
            events = new EventHandler();
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            events = null;
            Instance = null;
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            Server.RoundStarted += events.OnRoundStart;
            Server.RoundEnded += events.OnRoundEnd;
            Player.ChangingRole += events.OnChangingRole;
        }

        public void UnregisterEvents()
        {
            Server.RoundEnded -= events.OnRoundEnd;
            Server.RoundStarted -= events.OnRoundStart;
            Player.ChangingRole -= events.OnChangingRole;
        }
    }
}
