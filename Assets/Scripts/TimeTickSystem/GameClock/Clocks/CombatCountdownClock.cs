using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCountdownClock : CountdownClock
{
    public CombatCountdownClock(int mins, int secs) : base (mins, secs)
    {

    }

    //public override void OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    //{
    //    if (e.tick % ticksPerSecond == 0)
    //    {
    //        DecreaseBySecond();

    //        if (IsTimerFinished())
    //        {
    //            Unsubscribe();
    //            OnTimerFinish();
    //        }
    //        // Update view

    //        Debug.Log(string.Format("{0}:{1}", minutes, seconds));
    //    }
    //}

    //private bool IsTimerFinished()
    //{
    //    return seconds == 0 && minutes == 0;
    //}

    protected override void OnTimerFinish()
    {
        GameObject.Find("GameController").GetComponent<GameController>().combatController.StartCombat();
    }
}

