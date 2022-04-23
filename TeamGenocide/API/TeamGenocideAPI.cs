using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;
using System.Collections.Generic;

using TeamGenocide.Exceptions;

namespace TeamGenocide.API
{
    public static class TeamGenocideAPI
    {
        public static bool AnnouncementsAllowed = true;

        public static bool AnnouncedFfDeath = false;
        public static bool AnnouncedCiDeath = false;
        public static bool AnnouncedScpDeath = false;

        public static void AnnounceDeath(Side side)
        {
            if (!AnnouncementsAllowed)
                throw new AnnouncementsNotAllowedException("Death announcements are not allowed! Use \"toggle_announcements\" in the RA console to enable them.");

            if (IsSideAlive(side))
                throw new AnnouncementsNotAllowedException("The specified Side is alive!");

            if (side == Side.None || side == Side.Tutorial)
                throw new AnnouncementsNotAllowedException("Announcements are not allowed for this Side!");

            if (Plugin.Instance.Config.FacilityForceDeathAnnouncement is null || Plugin.Instance.Config.CiDeathAnnouncement is null || Plugin.Instance.Config.ScpDeathAnnouncement is null)
                throw new InvalidAnnouncementException("There was not an announcement set for this Side.");

            if (side == Side.Mtf)
            {
                Cassie.Message(Plugin.Instance.Config.FacilityForceDeathAnnouncement, true);
                AnnouncedFfDeath = true;
            }

            if (side == Side.ChaosInsurgency)
            {
                Cassie.Message(Plugin.Instance.Config.CiDeathAnnouncement, true);
                AnnouncedCiDeath = true;
            }
            if (side == Side.Scp)
            {
                Cassie.Message(Plugin.Instance.Config.ScpDeathAnnouncement, true);
                AnnouncedScpDeath = true;
            }
        }

        public static bool IsSideAlive(Side side)
        {
            int peopleAlive = 0;

            foreach (Player player in Player.List)
            {
                if (player.IsAlive && player.Role.Side == side)
                    peopleAlive++;
            }

            return peopleAlive > 0;
        }

        public static IEnumerator<float> CheckForSideDeath()
        {
            while (true)
            {
                if (!IsSideAlive(Side.Mtf) && !AnnouncedFfDeath)
                {
                    try
                    {
                        AnnounceDeath(Side.Mtf);
                    }
                    catch
                    {
                        continue;
                    }
                }

                if (!IsSideAlive(Side.ChaosInsurgency) && !AnnouncedCiDeath)
                {
                    try
                    {
                        AnnounceDeath(Side.ChaosInsurgency);
                    }
                    catch
                    {
                        continue;
                    }
                }

                if (!IsSideAlive(Side.Scp) && !AnnouncedScpDeath)
                {
                    try
                    {
                        AnnounceDeath(Side.Scp);
                    }
                    catch
                    {
                        continue;
                    }
                }
                yield return Timing.WaitForSeconds(2.5f);
            }
        }
    }
}
