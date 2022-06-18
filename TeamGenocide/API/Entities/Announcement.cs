using TeamGenocide.API.Enums;

namespace TeamGenocide.API.Entities
{
    public class Announcement
    {
        public Team Team { get; set; }

        public string AnnouncementCassie { get; set; }
        public string AnnouncementSubtitle { get; set; }
        public ushort DisplayFor { get; set; } = 5;

        public AnnouncementType AnnouncementType { get; set; }
    }
}
