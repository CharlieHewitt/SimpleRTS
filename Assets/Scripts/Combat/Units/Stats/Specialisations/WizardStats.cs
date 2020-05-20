using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardStats : UnitStats
{
    public WizardStats()
    {
        unitType = UnitType.WIZARD;
        attackDamage = 60;
        attackSpeed = 1;
        health = 70;
    }
}