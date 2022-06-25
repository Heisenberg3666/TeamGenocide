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

            if (!Plugin.Instance.Config.Announcements.TryGetValue(e.Player.Role.Team, out Announcement announcement))
                return;

            if (Player.List.Count(x => x.Role.Team == e.Player.Role.Team) <= 1)
                announcement.AnnounceDeath();
        }
    }
}
