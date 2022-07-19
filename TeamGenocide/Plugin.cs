using Exiled.API.Features;
using System;
using TeamGenocide.Events;

namespace TeamGenocide
{
    public class Plugin : Plugin<Config>
    {
        private PlayerEvents _playerEvents;

        public static Plugin Instance;

        public override string Name { get; } = "TeamGenocide";
        public override string Author { get; } = "Heisenberg3666";
        public override Version Version { get; } = new Version(2, 1, 3, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 2);

        public override void OnEnabled()
        {
            Instance = this;

            _playerEvents = new PlayerEvents(Config);

            RegisterEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            _playerEvents = null;

            Instance = null;

            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            _playerEvents.RegisterEvents();
        }

        public void UnregisterEvents()
        {
            _playerEvents.UnregisterEvents();
        }
    }
}
