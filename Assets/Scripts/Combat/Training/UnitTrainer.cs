using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTrainer : MonoBehaviour
{
    private int currentTick;
    private int requiredTicks;
    private UnitPurchaseModel model;

    // Used by Training Queue to see if the next unit can be sent to the trainer
    public bool isTraining { get; private set; }

    public UnitTrainer()
    {
        currentTick = 0;
        requiredTicks = 0;
        model = null;
    }

    public void StartTraining(UnitPurchaseModel model)
    {
        isTraining = true;

        requiredTicks = model.trainingTime;
        currentTick = 0;

        TimeTickSystem.OnTick += OnTick;
    }

    public void UpdateTraining()
    {
        if (currentTick < requiredTicks)
        {
            currentTick++;
        }
        else
        {
            Unsubscribe();
            isTraining = false;
            // unit complete -> notify ArmyController to add unit to army
            // fetch next from queue if possible
        }
    }

    public void OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        UpdateTraining();
    }

    public void Unsubscribe()
    {
        TimeTickSystem.OnTick -= OnTick;
    }
}
