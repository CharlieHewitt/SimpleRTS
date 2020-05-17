using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArmyCommandFactory
{
    public static GameBehaviourCommand CreateBuyUnitCommand(UnitType type)
    {
        return new BuyUnitCommand(type);
    }
}
