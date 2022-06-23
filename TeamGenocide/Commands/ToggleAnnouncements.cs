using CommandSystem;
using Exiled.Permissions.Extensions;
using System;
using TeamGenocide.API;

namespace TeamGenocide.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ToggleAnnouncements : ICommand
    {
        public string Command { get; } = "toggle_announcements";

        public string[] Aliases { get; } = new[] { "togg_ann" };

        public string Description { get; } = "If announcements from TeamGenocide plugin are allowed.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission($"teamgenocide.{Command}"))
            {
                response = "You do not have permission to use this command.";
                return false;
            }

            TeamGenocideAPI.AnnouncementsAllowed = !TeamGenocideAPI.AnnouncementsAllowed;
            response = $"Done. Announcements are set to {TeamGenocideAPI.AnnouncementsAllowed}.";
            return true;
        }
    }
}
