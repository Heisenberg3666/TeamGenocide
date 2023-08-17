using Exiled.API.Features;

namespace TeamGenocide.API.Entities
{
    public class Announcement
    {
        public string Cassie { get; set; }
        public string Subtitle { get; set; }
        public string Broadcast { get; set; }
        public string Hint { get; set; }
        public ushort DisplayTime { get; set; }
        public Lights Lights { get; set; }

        public void AnnounceDeath()
        {
            if (!string.IsNullOrEmpty(Cassie))
                AnnounceCassie();

            if (!string.IsNullOrEmpty(Broadcast))
                Map.Broadcast(DisplayTime, Broadcast);

            if (!string.IsNullOrEmpty(Hint))
                Map.ShowHint(Hint, DisplayTime);

            Lights?.ChangeLights();
            
            Log.Debug("Team death announced.");
        }

        private void AnnounceCassie()
        {
            if (string.IsNullOrEmpty(Subtitle))
                Exiled.API.Features.Cassie.Message(Cassie);
            else
                Exiled.API.Features.Cassie.MessageTranslated(Cassie, Subtitle);
            
            Log.Debug("Cassie has announced Team death.");
        }
    }
}
