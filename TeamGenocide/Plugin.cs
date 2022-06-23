using Exiled.API.Features;
using System;
using TeamGenocide.API;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace TeamGenocide
{
    public class Plugin : Plugin<Config>
    {
        private EventHandlers _events;
        private TeamGenocideApi _api;

        public static Plugin Instance;

        public override string Name { get; } = "TeamGenocide";
        public override string Author { get; } = "Heisenberg3666";
        public override Version Version { get; } = new Version(2, 1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 0);

        public override void OnEnabled()
        {
            Instance = this;
            _api = new TeamGenocideApi();
            _events = new EventHandlers(_api);

            RegisterEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            _events = null;
            _api = null;
            Instance = null;

            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            Player.ChangingRole += _events.OnChangingRole;
        }

        public void UnregisterEvents()
        {
            Player.ChangingRole -= _events.OnChangingRole;
        }
    }
}
