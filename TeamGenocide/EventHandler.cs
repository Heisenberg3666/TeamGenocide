using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System.Collections.Generic;
using System.Linq;
using TeamGenocide.API;
using TeamGenocide.API.Entities;

namespace TeamGenocide
{
    public class EventHandler
    {
        public void OnRoundStart()
        {
            IEnumerable<Announcement> announcements = Plugin.Instance.Config.Announcements;

            foreach (Announcement announcement in announcements)
                TeamGenocideAPI.DeathAnnounced[announcement.Team] = false;
        }

        public void OnRoundEnd(RoundEndedEventArgs ev)
        {
            TeamGenocideAPI.DeathAnnounced = null;
        }

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (Player.List.Where(x => x.Role.Team == ev.Player.Role.Team).Count() <= 1)
                TeamGenocideAPI.AnnounceDeath(ev.Player.Role.Team);
        }
    }
}
