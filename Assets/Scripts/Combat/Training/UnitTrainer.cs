using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTrainer
{
    PlayerType playerType;
    private int currentTick;
    private int requiredTicks;
    private UnitPurchaseModel model;

    // Used by Training Queue to see if the next unit can be sent to the trainer
    public bool isTraining { get; private set; }

    public UnitTrainer(PlayerType playerType)
    {
        this.playerType = playerType;
        isTraining = false;
        currentTick = 0;
        requiredTicks = 0;
        model = null;
    }

    public void StartTraining(UnitPurchaseModel model)
    {
        this.model = model;
        isTraining = true;

        requiredTicks = model.trainingTime;
        currentTick = 0;

        TimeTickSystem.OnTick += UnitTrainer_OnTick;
    }

    public void UpdateTraining()
    {
        if (currentTick < requiredTicks)
        {
            currentTick++;
            Debug.Log(string.Format("Training {0}/{1}", currentTick, requiredTicks));
        }
        else
        {
            Unsubscribe();
            Debug.Log("training complete");

            ArmyController armyController = GameObject.Find("GameController").GetComponent<GameController>().GetPlayerModel(playerType).armyController;
            armyController.AddCompleteUnit(model);
            isTraining = false;
            // unit complete -> notify ArmyController to add unit to army
            // fetch next from queue if possible
        }
    }

    public void UnitTrainer_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        UpdateTraining();
    }

    public void Unsubscribe()
    {
        TimeTickSystem.OnTick -= UnitTrainer_OnTick;
    }
}
