using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsmanStats : UnitStats
{
    public SwordsmanStats()
    {
        unitType = UnitType.SWORDSMAN;
        attackDamage = 35;
        attackSpeed = 1;
        health = 75;
    }
}