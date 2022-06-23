using Exiled.API.Features;
using System.Collections.Generic;
using TeamGenocide.API.Entities;
using TeamGenocide.API.Enums;

namespace TeamGenocide.API
{
    public static class TeamGenocideAPI
    {
        public static bool AnnouncementsAllowed = true;
        public static Dictionary<Team, bool> DeathAnnounced = new Dictionary<Team, bool>();

        public static void AnnounceDeath(Announcement announcement)
        {
            if (announcement.AnnouncementType.HasFlag(AnnouncementType.Cassie) &&
                !string.IsNullOrEmpty(announcement.AnnouncementCassie))
            {
                if (string.IsNullOrEmpty(announcement.AnnouncementSubtitle))
                    Cassie.Message(announcement.AnnouncementCassie);
                else
                    Cassie.MessageTranslated(announcement.AnnouncementCassie, announcement.AnnouncementSubtitle);
            }

            if (announcement.AnnouncementType.HasFlag(AnnouncementType.Broadcast) &&
                !string.IsNullOrEmpty(announcement.AnnouncementBroadcast))
                Map.Broadcast(announcement.DisplayFor, announcement.AnnouncementSubtitle);

            if (announcement.AnnouncementType.HasFlag(AnnouncementType.Hint) &&
                !string.IsNullOrEmpty(announcement.AnnouncementHint))
                Map.ShowHint(announcement.AnnouncementSubtitle, announcement.DisplayFor);
        }
    }
}
