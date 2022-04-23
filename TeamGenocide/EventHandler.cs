using Exiled.API.Enums;
using Exiled.Events.EventArgs;
using Exiled.API.Features;
using MEC;
using System.Collections.Generic;
using System.Linq;
using TeamGenocide.API;

namespace TeamGenocide
{
    public class EventHandler
    {
        public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();

        public void OnRoundStart()
        {
            Timing.CallDelayed(5f, () =>
            {
                Coroutines.Add(Timing.RunCoroutine(TeamGenocideAPI.CheckForSideDeath()));
            });

            int ciPlayers = 0;
            int mtfPlayers = 0;
            int scpPlayers = 0;

            foreach (Player player in Player.List)
            {
                if (player.Role.Side == Side.ChaosInsurgency)
                    ciPlayers++;
                if (player.Role.Side == Side.Mtf)
                    mtfPlayers++;
                if (player.Role.Side == Side.Scp)
                    scpPlayers++;
            }

            TeamGenocideAPI.AnnouncedCiDeath = ciPlayers == 0;
            TeamGenocideAPI.AnnouncedFfDeath = mtfPlayers == 0;
            TeamGenocideAPI.AnnouncedScpDeath = scpPlayers == 0;
        }

        public void OnRoundEnd(RoundEndedEventArgs ev)
        {
            Coroutines.Clear();
        }

        public void OnSpawnWave(RespawningTeamEventArgs ev)
        {
            if (ev.Players.FirstOrDefault().Role.Side == Side.Mtf)
                TeamGenocideAPI.AnnouncedFfDeath = false;
            if (ev.Players.FirstOrDefault().Role.Side == Side.ChaosInsurgency)
                TeamGenocideAPI.AnnouncedCiDeath = false;
        }

        public void OnDied(DiedEventArgs ev)
        {
            
        }
    }
}
