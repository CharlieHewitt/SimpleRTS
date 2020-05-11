using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitPurchaseModelFactory
{
    public static UnitPurchaseModel Create(UnitType unitType)
    {
        switch (unitType)
        {
            case UnitType.SWORDSMAN:
                return new SwordsmanPurchaseModel();

            case UnitType.ARCHER:
                return new ArcherPurchaseModel();

            case UnitType.WIZARD:
                return new WizardPurchaseModel();

            default:
                Debug.LogError(string.Format("No UnitPurchaseModel has been implemented for {0}", unitType));
                return null;
        }
    }

}
