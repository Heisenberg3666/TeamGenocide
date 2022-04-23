using CommandSystem;
using Exiled.Permissions.Extensions;
using System;
using TeamGenocide.API;

namespace TeamGenocide.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ToggleAnnouncements : ICommand
    {
        public string Command => "toggle_announcements";

        public string[] Aliases => new[] { "togg_ann" };

        public string Description => "If announcements from TeamGenocide plugin is allowed.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission($"teamgenocide.{Command}"))
            {
                response = "You do not have permissions to use this command.";
                return false;
            }

            TeamGenocideAPI.AnnouncementsAllowed = !TeamGenocideAPI.AnnouncementsAllowed;
            response = $"Done. Announcements are set to {TeamGenocideAPI.AnnouncementsAllowed}.";
            return true;
        }
    }
}
