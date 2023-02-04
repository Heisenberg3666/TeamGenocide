using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;
using UnityEngine;

namespace TeamGenocide.API.Entities
{
    public class Lights
    {
        public Color Color { get; set; }
        public IEnumerable<ZoneType> Zones { get; set; }
        public float Duration { get; set; }

        public void ChangeLights()
        {
            List<Room> rooms = new List<Room>();

            foreach (ZoneType zone in Zones) 
                rooms.AddRange(Room.Get(zone));
            
            foreach (Room room in rooms)
            {
                room.TurnOffLights(.25f);
                room.Color = Color;

                Timing.CallDelayed(Duration, () =>
                {
                    room.TurnOffLights(.25f);
                    room.ResetColor();
                });
            }
            
            Log.Debug("Lights have been changed.");
        }
    }
}