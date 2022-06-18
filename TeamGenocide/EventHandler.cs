using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;
using TeamGenocide.API;
using TeamGenocide.API.Entities;

namespace TeamGenocide
{
    public class EventHandler
    {
        public void OnRoundStart()
        {
            foreach (Announcement announcement in Plugin.Instance.Config.Announcements)
                TeamGenocideAPI.DeathAnnounced[announcement.Team] = false;
        }

        public void OnRoundEnd(RoundEndedEventArgs ev)
        {
            TeamGenocideAPI.DeathAnnounced = null;
        }

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (TeamGenocideAPI.PlayersInTeam(ev.Player.Role.Team) <= 1)
                TeamGenocideAPI.AnnounceDeath(ev.Player.Role.Team);
        }
    }
}
