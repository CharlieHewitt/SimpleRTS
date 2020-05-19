using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCountdownClock : CountdownClock
{
    public CombatCountdownClockView timerView;

    public CombatCountdownClock(int mins, int secs) : base (mins, secs)
    {
        timerView = GameObject.Find("CombatCountdownTimerView").GetComponent<CombatCountdownClockView>();
    }

    protected override void OnTimerFinish()
    {
        GameObject.Find("GameController").GetComponent<GameController>().combatController.StartCombat();
    }

    protected override void UpdateTimerView()
    {
        timerView.UpdateTime(minutes, seconds);
    }
}

