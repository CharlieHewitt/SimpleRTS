using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmySupplyView : MonoBehaviour
{
    public Text supply;

    public void UpdateSupply(string supplyStatus)
    {
        supply.text = supplyStatus;
    }
}
