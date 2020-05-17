using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyController: MonoBehaviour
{
    private Army army;

    private void Awake()
    {
        army = new Army();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //if (army.CheckSupply(UnitPurchaseModelFactory.Create(UnitType.WIZARD)))
            //{
            //    army.ReserveSupply(UnitPurchaseModelFactory.Create(UnitType.WIZARD));
            //    army.AddUnit(UnitPurchaseModelFactory.Create(UnitType.WIZARD));
            //}
            //else
            //{
            //    Debug.Log("not enough supply available");
            //}
            Debug.Log(army.StatusString());
            Debug.Log(army.QueueStatus());
        }
    }

    public void AddCompleteUnit(UnitPurchaseModel model)
    {
        army.AddCompleteUnit(model);
    }

    public bool CheckSupply(UnitPurchaseModel model)
    {
        return army.CheckSupply(model);
    }

    public void AddUnitToBuildQueue(UnitPurchaseModel model)
    {
        army.ReserveSupply(model);
        army.AddUnit(model);
    }


}