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

            if (Plugin.Instance.Config.FfDeathAnnouncement is null || Plugin.Instance.Config.CiDeathAnnouncement is null || Plugin.Instance.Config.ScpDeathAnnouncement is null)
                throw new InvalidAnnouncementException("There was not an announcement set for this Side.");

            if (side == Side.Mtf)
            {
                Cassie.MessageTranslated(Plugin.Instance.Config.FfDeathAnnouncement, Plugin.Instance.Config.FfSubtitles);
                Log.Debug("Announcing death.", Plugin.Instance.Config.DebugMode);
                AnnouncedFfDeath = true;
                Log.Debug("Set AnnouncedFfDeath to true.", Plugin.Instance.Config.DebugMode);
            }

            if (side == Side.ChaosInsurgency)
            {
                Cassie.MessageTranslated(Plugin.Instance.Config.CiDeathAnnouncement, Plugin.Instance.Config.CiSubtitles);
                Log.Debug("Announcing death.", Plugin.Instance.Config.DebugMode);
                AnnouncedCiDeath = true;
                Log.Debug("Set AnnouncedCiDeath to true.", Plugin.Instance.Config.DebugMode);
            }
            if (side == Side.Scp)
            {
                Cassie.MessageTranslated(Plugin.Instance.Config.ScpDeathAnnouncement, Plugin.Instance.Config.ScpSubtitles);
                Log.Debug("Announcing death.", Plugin.Instance.Config.DebugMode);
                AnnouncedScpDeath = true;
                Log.Debug("Set AnnouncedScpDeath to true.", Plugin.Instance.Config.DebugMode);
            }
        }

        public static Side RoleSide(RoleType role)
        {
            if (role == RoleType.NtfSergeant || role == RoleType.NtfCaptain || role == RoleType.NtfPrivate || role == RoleType.NtfSpecialist || role == RoleType.Scientist)
                return Side.Mtf;
            if (role == RoleType.ChaosRepressor || role == RoleType.ChaosMarauder || role == RoleType.ChaosConscript || role == RoleType.ChaosRifleman || role == RoleType.ClassD)
                return Side.ChaosInsurgency;
            if (role == RoleType.Scp049 || role == RoleType.Scp0492 || role == RoleType.Scp079 || role == RoleType.Scp096 || role == RoleType.Scp106 || role == RoleType.Scp173 || role.Is939())
                return Side.Scp;
            if (role == RoleType.None)
                return Side.None;
            return Side.Tutorial;
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
