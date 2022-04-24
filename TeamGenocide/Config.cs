using Exiled.API.Interfaces;
using System.ComponentModel;

namespace TeamGenocide
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Enable to help find bug sources.")]
        public bool DebugMode { get; set; } = false;

        [Description("What to announce when all SCP's are dead. (Leave blank to not announce anything)")]
        public string ScpDeathAnnouncement { get; set; } = "All SCPs have been secured .";
        [Description("Set custom subtitles for the above announcement.")]
        public string ScpSubtitles { get; set; } = "All SCPs have been secured.";
        [Description("What to announce when all Chaos Insurgency forces are dead. (Leave blank to not announce anything)")]
        public string CiDeathAnnouncement { get; set; } = "All Chaos Insurgency have been secured . . Allremaining .";
        [Description("Set custom subtitles for the above announcement.")]
        public string CiSubtitles { get; set; } = "All Chaos Insurgency have been secured. All remaining personnel are advised to proceed with standards evacuation protocols and wait for an MTF squad to reach their destination.";
        [Description("What to announce when all Facility Forces are dead. (Leave blank to not announce anything)")]
        public string FfDeathAnnouncement { get; set; } = "All Facility Forces are dead . . Allremaining .";
        [Description("Set custom subtitles for the above announcement.")]
        public string FfSubtitles { get; set; } = "All Facility Forces are dead. All remaining personnel are advised to proceed with standards evacuation protocols and wait for an MTF squad to reach their destination.";
    }
}
