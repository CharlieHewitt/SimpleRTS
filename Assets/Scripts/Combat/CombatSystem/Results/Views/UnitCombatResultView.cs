using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCombatResultView : MonoBehaviour
{
    // outcome
    public Text numUnits;

    private void Awake()
    {
        //numUnits.text = "0\n(-0)";
    }

    public void UpdateNumUnits(int startingUnits, int casualties)
    {
        numUnits.text = string.Format("{0}\n(-{1})", startingUnits, casualties);
    }

}