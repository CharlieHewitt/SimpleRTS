using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitStatsFactory
{
    public static UnitStats Create(UnitType unitType)
    {
        switch (unitType)
        {
            case UnitType.SWORDSMAN:
                return new SwordsmanStats();

            case UnitType.ARCHER:
                return new ArcherStats();

            case UnitType.WIZARD:
                return new WizardStats();

            default:
                Debug.LogError(string.Format("No UnitStats has been implemented for {0}", unitType));
                return null;
        }
    }

}
