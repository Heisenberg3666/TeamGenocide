﻿using Exiled.API.Features;
using System;
using TeamGenocide.Events;

namespace TeamGenocide
{
    public class Plugin : Plugin<Config>
    {
        private PlayerEvents _playerEvents;

        public override string Name { get; } = "TeamGenocide";
        public override string Author { get; } = "Heisenberg3666";
        public override Version Version { get; } = new Version(2, 4, 2, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 3, 9);

        public override void OnEnabled()
        {
            _playerEvents = new PlayerEvents(Config);

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            _playerEvents = null;

            base.OnDisabled();
        }
    }
}
