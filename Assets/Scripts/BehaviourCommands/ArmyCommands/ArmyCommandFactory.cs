using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArmyCommandFactory
{
    public static GameBehaviourCommand CreateBuyUnitCommand(UnitType unitType, PlayerType playerType)
    {
        return new BuyUnitCommand(unitType, playerType);
    }
}
