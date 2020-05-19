using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardStats : UnitStats
{
    public WizardStats()
    {
        unitType = UnitType.WIZARD;
        attackDamage = 70;
        attackSpeed = 1;
        health = 71;
    }
}