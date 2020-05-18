using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyController: MonoBehaviour
{
    // models
    private Army army;

    // views
    private Dictionary<UnitType, UnitView> unitViews;
    private ArmySupplyView supplyView;

    private void Awake()
    {
        army = new Army();
        InitialiseUnitViews();
        InitialiseSupplyView();

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
    // View related code

    public void InitialiseUnitViews()
    {
        unitViews = new Dictionary<UnitType, UnitView>();

        unitViews[UnitType.SWORDSMAN] = GameObject.Find("UnitPanel - Swordsman").GetComponent<UnitView>();
        unitViews[UnitType.ARCHER] = GameObject.Find("UnitPanel - Archer").GetComponent<UnitView>();
        unitViews[UnitType.WIZARD] = GameObject.Find("UnitPanel - Wizard").GetComponent<UnitView>();
    }

    public void UpdateUnitView(UnitType type)
    {
        int numUnits = army.GetNumber(type);
        unitViews[type].UpdateNumUnits(numUnits);
    }

    public void UpdateSupplyView()
    {
        supplyView.UpdateSupply(army.SupplyStatus());
    }

    public void InitialiseSupplyView()
    {
        supplyView = GameObject.Find("Important Numbers panel").GetComponent<ArmySupplyView>();
        UpdateSupplyView();
    }




}