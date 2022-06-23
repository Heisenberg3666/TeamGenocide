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
            if (!TeamGenocideAPI.AnnouncementsAllowed &&
                ev.Player.Role.Team == Team.RIP)
                return;

            if (Player.List.FirstOrDefault(x => x.Role.Team == ev.Player.Role.Team) != null)
            {
                Announcement announcement = Plugin.Instance.Config.Announcements
                    .FirstOrDefault(x => x.Team == ev.Player.Role.Team);

                if (announcement != null)
                    TeamGenocideAPI.AnnounceDeath(announcement);
            }
        }
    }
}
