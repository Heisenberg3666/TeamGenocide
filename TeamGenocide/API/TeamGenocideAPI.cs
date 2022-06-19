using Exiled.API.Features;
using System.Collections.Generic;
using System.Linq;
using TeamGenocide.API.Entities;
using TeamGenocide.API.Enums;

namespace TeamGenocide.API
{
    public static class TeamGenocideAPI
    {
        public static bool AnnouncementsAllowed = true;
        public static Dictionary<Team, bool> DeathAnnounced = new Dictionary<Team, bool>();

        public static void AnnounceDeath(Team team)
        {
            Announcement announcement = Plugin.Instance.Config.Announcements.FirstOrDefault(x => x.Team == team);

            if (announcement is null ||
                team == Team.RIP ||
                !AnnouncementsAllowed)
                return;

            if (announcement.AnnouncementType.HasFlag(AnnouncementType.Cassie) &&
                !string.IsNullOrEmpty(announcement.AnnouncementCassie) &&
                !string.IsNullOrEmpty(announcement.AnnouncementSubtitle))
                Cassie.MessageTranslated(announcement.AnnouncementCassie, announcement.AnnouncementSubtitle);
            else if (announcement.AnnouncementType.HasFlag(AnnouncementType.Cassie) &&
                !string.IsNullOrEmpty(announcement.AnnouncementCassie))
                Cassie.Message(announcement.AnnouncementCassie);

            if (announcement.AnnouncementType.HasFlag(AnnouncementType.Broadcast) &&
                !string.IsNullOrEmpty(announcement.AnnouncementSubtitle))
                for (int i = 0; i < Player.List.Count(); i++)
                    Player.List.ToList()[i].Broadcast(announcement.DisplayFor, announcement.AnnouncementSubtitle);

            if (announcement.AnnouncementType.HasFlag(AnnouncementType.Hint) &&
                !string.IsNullOrEmpty(announcement.AnnouncementSubtitle))
                for (int i = 0; i < Player.List.Count(); i++)
                    Player.List.ToList()[i].ShowHint(announcement.AnnouncementSubtitle, announcement.DisplayFor);

            DeathAnnounced[team] = true;
        }
    }
}
