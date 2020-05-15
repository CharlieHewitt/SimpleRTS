using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameBehaviourCommand
{
    // do we need to store this? -> could be useful for Factory but prob not here
    protected GameBehaviourCommandType commandType;

    // Player or AI controllers/command
    // private Player invoker?

    
    // Code that needs to be run when added to queue
    public abstract bool OnCreate();

    // Code that needs to be executed -> Can subscribe to time tick system if needed!
    public abstract void Execute();

    protected bool PayOutTransaction(ResourceTransaction transaction)
    {
        ResourceController resourceController = GameObject.Find("Resource System").GetComponent<ResourceController>();
        return resourceController.PayOutTransaction(transaction);
    }

    // Add utility methods for "getting controllers"

    protected ResourceController GetResourceController()
    {
        return GameObject.Find("Resource System").GetComponent<ResourceController>();
    }

    protected BuildPlotController GetBuildPlotController()
    {
        return GameObject.Find("GameBehaviourController").GetComponent<GameBehaviourCommandController>().buildPlotController;
    }
}
