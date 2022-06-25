using Exiled.API.Features;
using System;
using Player = Exiled.Events.Handlers.Player;

namespace TeamGenocide
{
    public class Plugin : Plugin<Config>
    {
        private EventHandlers _events;

        public static Plugin Instance;

        public override string Name { get; } = "TeamGenocide";
        public override string Author { get; } = "Heisenberg3666";
        public override Version Version { get; } = new Version(2, 1, 1, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 0);

        public override void OnEnabled()
        {
            Instance = this;

            _events = new EventHandlers();

            RegisterEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            _events = null;

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
