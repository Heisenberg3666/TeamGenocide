using Exiled.API.Features;
using TeamGenocide.API.Entities;
using TeamGenocide.API.Enums;

namespace TeamGenocide.API
{
    public class TeamGenocideApi
    {
        public void AnnounceDeath(Announcement announcement)
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
