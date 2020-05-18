using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitView : MonoBehaviour
{
    public UnitType type;

    public Text numUnits;
    public Text unitStats;
    public Text purchaseInfo;

    private void SetUnitInfo()
    {
        numUnits.text = "0";
        SetUnitStats();
        SetPurchaseInfo();
    }

    private void SetUnitStats()
    {
        UnitStats stats = UnitStatsFactory.Create(type);

        unitStats.text = string.Format("Damage: {0} \nHealth: {1}", stats.attackDamage, stats.health);
    }

    private void SetPurchaseInfo()
    {
        UnitPurchaseModel model = UnitPurchaseModelFactory.Create(type);
        string wood = model.buildCost.GetResourceCost(ResourceType.WOOD);
        string magicStone = model.buildCost.GetResourceCost(ResourceType.MAGIC_STONE);
        string buildTime = (model.trainingTime / 5).ToString() + "s";

        purchaseInfo.text = string.Format("Supply: {0}\nWood: {1}\nMagic Stone: {2}\nBuild Time: {3}", model.armySize, wood, magicStone, buildTime);
    }

    private void Awake()
    {
        SetUnitInfo();
    }

    public void UpdateNumUnits(int num)
    {
        numUnits.text = num.ToString();
    }

    public void QueueTrainUnitCommand()
    {
        Debug.Log("clicky");
        GameBehaviourCommand command = ArmyCommandFactory.CreateBuyUnitCommand(type);

        GameObject.Find("GameBehaviourController").GetComponent<GameBehaviourCommandController>().QueueUpCommand(command);
    }
}
