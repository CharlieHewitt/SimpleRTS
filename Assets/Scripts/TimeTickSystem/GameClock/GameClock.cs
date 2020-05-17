using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameClock
{
    protected int minutes;
    protected int seconds;
    protected int ticksPerSecond;

    public GameClock()
    {
        seconds = 0;
        minutes = 0;
        ticksPerSecond = CalculateTicksPerSecond();
    }

    protected int CalculateTicksPerSecond()
    {
       return ticksPerSecond = (int)(1f / TimeTickSystem.TICK_TIMER_MAX);
    }

    public abstract void OnTick(object sender, TimeTickSystem.OnTickEventArgs e);

    protected void Unsubscribe()
    {
        TimeTickSystem.OnTick -= OnTick;
    }

    protected void IncreaseBySecond()
    {
        if (seconds == 59)
        {
            minutes++;
            seconds = 0;
        }
        else
        {
            seconds++;
        }
    }

    protected void DecreaseBySecond()
    {
        if (seconds == 0)
        {
            minutes--;
            seconds = 59;
        }
        else
        {
            seconds--;
        }
    }
}

