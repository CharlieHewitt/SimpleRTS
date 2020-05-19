using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLengthClock : GameClock
{
    public GameClockView clockView;
    public GameLengthClock()
    {
        clockView = GameObject.Find("GameClockView").GetComponent<GameClockView>();
        TimeTickSystem.OnTick += OnTick;
        
    }

    public override void OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if (e.tick % ticksPerSecond == 0)
        {
            IncreaseBySecond();
            // Update view
            UpdateTimerView();

            Debug.Log(string.Format("{0}:{1}", minutes, seconds));
        }
    }

    protected override void UpdateTimerView()
    {
        clockView.UpdateTime(minutes, seconds);
    }
}

