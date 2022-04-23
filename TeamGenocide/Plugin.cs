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
        public override Version Version => new Version(1, 0, 0, 0);
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
            Player.Died += events.OnDied;
            Server.RoundStarted += events.OnRoundStart;
            Server.RoundEnded += events.OnRoundEnd;
            Server.RespawningTeam += events.OnSpawnWave;
        }

        public void UnregisterEvents()
        {
            Server.RoundEnded -= events.OnRoundEnd;
            Server.RoundStarted -= events.OnRoundStart;
            Player.Died -= events.OnDied;
        }
    }
}
