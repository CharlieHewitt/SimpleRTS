using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    private CombatInstance combatInstance;

    private void Awake()
    {
        combatInstance = new CombatInstance();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // do a thing
            combatInstance.RunCombat();
        }
    }
}