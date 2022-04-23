using Exiled.API.Interfaces;
using System.ComponentModel;

namespace TeamGenocide
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("What to announce when all SCP's are dead. (Leave blank to not announce anything)")]
        public string ScpDeathAnnouncement { get; set; } = "All SCPs have been secured .";
        [Description("What to announce when all Chaos Insurgency forces are dead. (Leave blank to not announce anything)")]
        public string CiDeathAnnouncement { get; set; } = "All Chaos Insurgency have been secured . . Allremaining .";
        [Description("What to announce when all Facility Forces are dead. (Leave blank to not announce anything)")]
        public string FfDeathAnnouncement { get; set; } = "All Facility Forces are dead . . Allremaining .";
    }
}
