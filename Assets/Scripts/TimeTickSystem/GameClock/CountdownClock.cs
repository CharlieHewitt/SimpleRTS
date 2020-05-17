using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownClock : GameClock
{
    public CountdownClock(int mins, int secs)
    {
        minutes = mins;
        seconds = secs;
        
        TimeTickSystem.OnTick += OnTick;
    }

    public override void OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if (e.tick % ticksPerSecond == 0)
        {
            DecreaseBySecond();

            if (IsTimerFinished())
            {
                Unsubscribe();
                OnTimerFinish();
            }
            // Update view

             Debug.Log(string.Format("{0}:{1}", minutes, seconds));
        }
    }

    private bool IsTimerFinished()
    {
        return seconds == 0 && minutes == 0;
    }

    private void OnTimerFinish()
    {
        Debug.Log("combat time");
    }
}

