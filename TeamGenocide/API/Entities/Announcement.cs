using TeamGenocide.API.Enums;

namespace TeamGenocide.API.Entities
{
    public class Announcement
    {
        public Team Team { get; set; }

        public string AnnouncementCassie { get; set; }
        public string AnnouncementSubtitle { get; set; }

        public AnnouncementType AnnouncementType { get; set; }
    }
}
