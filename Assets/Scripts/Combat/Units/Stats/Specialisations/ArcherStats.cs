using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherStats : UnitStats
{
    public ArcherStats()
    {
        unitType = UnitType.ARCHER;
        attackDamage = 45;
        attackSpeed = 1;
        health = 100;
    }
}