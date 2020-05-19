using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScheduler
{
    private CombatCountdownClock combatCountdownClock;

    public void ScheduleCombat(int mins, int seconds)
    {
        combatCountdownClock = new CombatCountdownClock(mins, seconds);
    }

    public void ScheduleCombatRound(int round)
    {
        if (round == 1)
        {
            ScheduleCombat(2, 0);
        }
        else
        {
            ScheduleCombat(3, 0);
        }
    }
}