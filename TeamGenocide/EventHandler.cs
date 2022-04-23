using Exiled.API.Enums;
using Exiled.Events.EventArgs;
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
