using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInstance
{
    private ActiveUnits player1Units;
    private ActiveUnits player2Units;

    public UnitStats unit1 { get; private set; }
    public UnitStats unit2 { get; private set; }

    public CombatInstance()
    {
        player1Units = null;
        player2Units = null;
        unit1 = null;
        unit2 = null;
    }

    public void SetPlayer1Units(UnitMap armyUnitMap)
    {
        player1Units = new ActiveUnits(armyUnitMap);
    }

    public void SetPlayer2Units(UnitMap armyUnitMap)
    {
        player2Units = new ActiveUnits(armyUnitMap);
    }

    public void SetUpCombatInstance()
    {
        UnitMap testMap = new UnitMap();
        testMap.AddMultiple(UnitType.SWORDSMAN, 40);
        // testMap.Add(UnitType.SWORDSMAN);
        testMap.AddMultiple(UnitType.SWORDSMAN, 20);
        testMap.AddMultiple(UnitType.WIZARD, 20);
        testMap.AddMultiple(UnitType.ARCHER, 20);


        UnitMap testMap2 = new UnitMap();
        testMap2.AddMultiple(UnitType.ARCHER, 20);
        testMap2.AddMultiple(UnitType.SWORDSMAN, 60);
        testMap2.Add(UnitType.SWORDSMAN);

        SetPlayer1Units(testMap);
        SetPlayer2Units(testMap2);
    }

    public void RunCombat()
    {
        SetUpCombatInstance();
        PlayerCombatResult result = SimulatePlayerCombat();

        Debug.Log(result);

        Debug.Log("player1:");
        Debug.Log(player1Units.MapStatusString());
        Debug.Log("player2:");
        Debug.Log(player2Units.MapStatusString());

        // update views + unit counts + player hps
    }

    public UnitCombatResult SimulateUnitCombat()
    {
        // Attack each other
        bool unit2Alive = Attack(unit1, unit2);
        bool unit1Alive = Attack(unit2, unit1);

        // Get result
        UnitCombatResult result;

        if (unit1Alive && unit2Alive)
        {
            result = UnitCombatResult.BOTH_ALIVE;
        }
        else if (unit1Alive)
        {
            result = UnitCombatResult.UNIT2_DEAD;
        }
        else if (unit2Alive)
        {
            result = UnitCombatResult.UNIT1_DEAD;
        }
        else
        {
            result = UnitCombatResult.BOTH_DEAD;
        }

        Debug.Log(result);
        return result;
    }

    public PlayerCombatResult SimulatePlayerCombat()
    {
        unit1 = player1Units.RandomlySelectUnit();
        unit2 = player2Units.RandomlySelectUnit();

        // while both players have units
        while (unit1 != null && unit2 != null)
        {
            UnitCombatResult unitResult = SimulateUnitCombat();

            ReinforceBattle(unitResult);
        }

        if (unit1 == null && unit2 == null)
        {
            return PlayerCombatResult.DRAW;
        }
        else if (unit1 == null)
        {
            // ADD unit2 back to player2units!
            player2Units.AddUnit(unit2.unitType);
            return PlayerCombatResult.PLAYER2_WIN;
        }
        else
        {
            // ADD unit1 back to player2units!
            player1Units.AddUnit(unit1.unitType);
            return PlayerCombatResult.PLAYER1_WIN;
        }
    }

    public void ReinforceBattle(UnitCombatResult unitCombatResult)
    {
        if (unitCombatResult == UnitCombatResult.UNIT1_DEAD ||unitCombatResult ==  UnitCombatResult.BOTH_DEAD)
        {
            unit1 = player1Units.RandomlySelectUnit();
        }
        
        if (unitCombatResult == UnitCombatResult.UNIT2_DEAD || unitCombatResult == UnitCombatResult.BOTH_DEAD)
        {
            unit2 = player2Units.RandomlySelectUnit();
        }
    }

    public bool Attack(UnitStats attackingUnit, UnitStats defendingUnit)
    {
        //Debug.Log(string.Format("attacking unit ad {0} , defending unit hp {1}", attackingUnit.attackDamage, defendingUnit.health));
        int damage = attackingUnit.CalculateDamageAgainst(defendingUnit.unitType);

        bool result = defendingUnit.TakeDamage(damage);

       // Debug.Log(string.Format("attacking unit ad {0} , defending unit hp {1}", attackingUnit.attackDamage, defendingUnit.health));
        return result;
    }
}
