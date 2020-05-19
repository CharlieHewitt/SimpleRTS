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
    
    
    
    // ----------------------------------- Combat related methods, probably should be in a wrapper but ah well
    
    // Return value -> Is unit still alive
    public bool TakeDamage(int damage)
    {
        bool alive = true;

        if (damage >= health)
        {
            health = 0;
            alive = false;
        }
        else
        {
            health -= damage;
        }


        return alive;
    }

    // for type modifications
    public int CalculateDamageAgainst(UnitType unitType)
    {
        return attackDamage;
    }


    //// Strength/ Weakness grants a {20%} damage boost -> next version
    //public List<UnitType> strongAgainst { get; protected set; }

    //public List<UnitType> weakAgainst { get; protected set; }
}
