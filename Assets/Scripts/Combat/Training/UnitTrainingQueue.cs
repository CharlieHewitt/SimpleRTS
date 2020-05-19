using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// This is a wrapper controlling access to a map of <BuildPlotLocation, BuildPlot>
public class UnitTrainingQueue
{
    private PlayerType playerType;
    private Queue<UnitPurchaseModel> trainingQueue;

    private UnitTrainer trainer;

    public UnitTrainingQueue(PlayerType playerType)
    {
        this.playerType = playerType;
        trainingQueue = new Queue<UnitPurchaseModel>(); 
        trainer = new UnitTrainer(playerType);

        StartTrainingQueue();
    }

    public void AddToQueue(UnitPurchaseModel model)
    {
        trainingQueue.Enqueue(model);
    }

    public void TrainUnit(UnitPurchaseModel model)
    {
        trainer.StartTraining(model);
    }

    public void TryTrainNextUnit()
    {
        if (!trainer.isTraining)
        {
            UnitPurchaseModel model = trainingQueue.Dequeue();
            trainer.StartTraining(model);

            Debug.Log(QueueStatus());
        }
    }

    public void StartTrainingQueue()
    {
        TimeTickSystem.OnTick += OnTick;
    }

    public void OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if (trainingQueue.Count != 0)
        {
            TryTrainNextUnit();
        }
    }

    public void Unsubscribe()
    {
        TimeTickSystem.OnTick -= OnTick;
    }

    public string QueueStatus()
    {
        string output = "unitQueue: ";

        foreach (UnitPurchaseModel model in trainingQueue)
        {
            output += string.Format("{0} , ", model.unitType);
        }

        output += string.Format(" ({0})", trainingQueue.Count);

        return output;
    }

}