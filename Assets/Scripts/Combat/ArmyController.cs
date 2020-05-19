using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArmyController
{
    private PlayerType playerType;

    // models
    public Army army { get; private set; }

    // views
    private Dictionary<UnitType, UnitView> unitViews;
    private ArmySupplyView supplyView;

    public ArmyController(PlayerType playerType)
    {
        this.playerType = playerType;
        army = new Army(playerType);
        InitialiseUnitViews();
        InitialiseSupplyView();

    }

    public void AddCompleteUnit(UnitPurchaseModel model)
    {
        army.AddCompleteUnit(model);
        UpdateUnitView(model.unitType);

    }

    public bool CheckSupply(UnitPurchaseModel model)
    {
        return army.CheckSupply(model);
    }

    public void AddUnitToBuildQueue(UnitPurchaseModel model)
    {
        army.ReserveSupply(model);
        UpdateSupplyView();
        army.AddUnit(model);
    }

    public UnitMap GetUnitsForCombat()
    {
        return army.unitMap;
    }

    public void IncreaseSupplyCap(int number)
    {
        army.IncreaseSupply(number);
        UpdateSupplyView();
    }

    public void UpdateArmy(UnitMap casualties)
    {
        foreach(UnitType type in Enum.GetValues(typeof(UnitType)).Cast<UnitType>())
        {
            int numDeaths = casualties.GetNumber(type);

            for (int i = 0; i < numDeaths; i++)
            {
                army.RemoveUnit(type);

            }
            //update views
            UpdateSupplyView();
            UpdateUnitView(type);
        }
    }

    //--------------- View related code

    private void InitialiseUnitViews()
    {
        if (playerType == PlayerType.AI)
        {
            return;
        }

        unitViews = new Dictionary<UnitType, UnitView>();

        unitViews[UnitType.SWORDSMAN] = GameObject.Find("UnitPanel - Swordsman").GetComponent<UnitView>();
        unitViews[UnitType.ARCHER] = GameObject.Find("UnitPanel - Archer").GetComponent<UnitView>();
        unitViews[UnitType.WIZARD] = GameObject.Find("UnitPanel - Wizard").GetComponent<UnitView>();
    }

    private void UpdateUnitView(UnitType type)
    {
        if (playerType == PlayerType.AI)
        {
            return;
        }

        int numUnits = army.GetNumber(type);
        unitViews[type].UpdateNumUnits(numUnits);
    }

    private void UpdateSupplyView()
    {
        if (playerType == PlayerType.AI)
        {
            return;
        }

        supplyView.UpdateSupply(army.SupplyStatus());
    }

    private void InitialiseSupplyView()
    {
        if (playerType == PlayerType.AI)
        {
            return;
        }

        supplyView = GameObject.Find("Important Numbers panel").GetComponent<ArmySupplyView>();
        UpdateSupplyView();
    }

    // Legacy code --------------

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        //if (army.CheckSupply(UnitPurchaseModelFactory.Create(UnitType.WIZARD)))
    //        //{
    //        //    army.ReserveSupply(UnitPurchaseModelFactory.Create(UnitType.WIZARD));
    //        //    army.AddUnit(UnitPurchaseModelFactory.Create(UnitType.WIZARD));
    //        //}
    //        //else
    //        //{
    //        //    Debug.Log("not enough supply available");
    //        //}
    //        Debug.Log(army.StatusString());
    //        Debug.Log(army.QueueStatus());
    //    }
    //}


}