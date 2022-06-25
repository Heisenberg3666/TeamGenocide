using Exiled.API.Features;

namespace TeamGenocide.API.Entities
{
    public class Announcement
    {
        public string Cassie { get; set; }
        public string Subtitle { get; set; }
        public string Broadcast { get; set; }
        public string Hint { get; set; }
        public ushort DisplayFor { get; set; } = 5;

        public void AnnounceDeath()
        {
            if (!string.IsNullOrEmpty(Cassie))
                AnnounceCassie();

            if (!string.IsNullOrEmpty(Broadcast))
                Map.Broadcast(DisplayFor, Broadcast);

            if (!string.IsNullOrEmpty(Hint))
                Map.ShowHint(Hint, DisplayFor);
        }

        private void AnnounceCassie()
        {
            if (string.IsNullOrEmpty(Subtitle))
                Exiled.API.Features.Cassie.Message(Cassie);
            else
                Exiled.API.Features.Cassie.MessageTranslated(Cassie, Subtitle);
        }
    }
}
