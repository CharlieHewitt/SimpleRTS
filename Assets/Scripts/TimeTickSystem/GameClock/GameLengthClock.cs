using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLengthClock : GameClock
{
    public GameLengthClock()
    {
        TimeTickSystem.OnTick += OnTick;
    }

    public override void OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if (e.tick % ticksPerSecond == 0)
        {
            IncreaseBySecond();
            // Update view

           // Debug.Log(string.Format("{0}:{1}", minutes, seconds));
        }
    }
}

