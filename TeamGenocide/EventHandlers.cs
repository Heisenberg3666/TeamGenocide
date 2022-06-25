using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System.Linq;
using TeamGenocide.API.Entities;

namespace TeamGenocide
{
    public class EventHandlers
    {
        public void OnChangingRole(ChangingRoleEventArgs e)
        {
            if (e.Player.Role.Team == Team.RIP)
                return;

            if (Player.List.Any(x => x.Role.Team == e.Player.Role.Team))
            {
                if (Plugin.Instance.Config.Announcements.TryGetValue(e.Player.Role.Team, out Announcement announcement))
                    announcement.AnnounceDeath();
            }
        }
    }
}
