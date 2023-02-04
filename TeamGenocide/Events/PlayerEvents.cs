using System.Collections.Generic;
using Exiled.API.Features;
using System.Linq;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using TeamGenocide.API.Entities;

namespace TeamGenocide.Events
{
    internal class PlayerEvents
    {
        private readonly Config _config;

        public PlayerEvents(Config config)
        {
            _config = config;
            Exiled.Events.Handlers.Player.ChangingRole += OnChangingRole;
        }

        ~PlayerEvents()
        {
            Exiled.Events.Handlers.Player.ChangingRole -= OnChangingRole;
        }

        private void OnChangingRole(ChangingRoleEventArgs e)
        {
            // Guard clauses
            if (e.Player.Role.Team == Team.Dead)
                return;

            if (!_config.Announcements.TryGetValue(e.Player.Role.Team, out List<Announcement> announcements))
                return;

            if (announcements.IsEmpty())
                return;
            
            // Calculations to determine if player is the last on the team.
            if (Player.List.Count(x => x.Role.Team == e.Player.Role.Team) <= 1)
                announcements.RandomItem().AnnounceDeath();
        }
    }
}
