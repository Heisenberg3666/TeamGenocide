using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System.Collections.Generic;
using System.Linq;
using TeamGenocide.API;
using TeamGenocide.API.Entities;

namespace TeamGenocide
{
    public class EventHandlers
    {
        private readonly TeamGenocideApi _api;

        public EventHandlers(TeamGenocideApi api)
        {
            _api = api;
        }

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.Player.Role.Team == Team.RIP)
                return;

            if (Player.List.FirstOrDefault(x => x.Role.Team == ev.Player.Role.Team) != null)
            {
                if (Plugin.Instance.Config.Announcements.TryGetValue(ev.Player.Role.Team, out Announcement announcement))
                    _api.AnnounceDeath(announcement);
            }
        }
    }
}
