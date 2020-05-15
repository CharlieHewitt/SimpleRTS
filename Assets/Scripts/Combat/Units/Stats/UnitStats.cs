using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitStats
{
    public UnitType unitType { get; protected set; }

    // game ticks
    public int attackDamage { get; protected set; }

    public int attackSpeed { get; protected set; }

    public int health { get; protected set; }


    //// Strength/ Weakness grants a {20%} damage boost
    //public List<UnitType> strongAgainst { get; protected set; }

    //public List<UnitType> weakAgainst { get; protected set; }
}
