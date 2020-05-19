using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameBehaviourCommand
{
    // invoker
    protected PlayerType playerType;

    // do we need to store this? -> could be useful for Factory but prob not here
    protected GameBehaviourCommandType commandType;

    // Code that needs to be executed -> Can subscribe to time tick system if needed!
    public abstract bool Execute();


    //  Utility method for making transactions (avoiding code duplication)
    protected bool PayOutTransaction(ResourceTransaction transaction)
    {
        ResourceController resourceController = GetResourceController();
        return resourceController.PayOutTransaction(transaction);
    }


    // ----------- Utility methods for accessing controllers (cleaner code in commands)

    protected GameController GetGameController()
    {
        return GameObject.Find("GameController").GetComponent<GameController>();
    }

    protected ResourceController GetResourceController()
    {
        return GetGameController().GetPlayerModel(playerType).resourceController;
    }

    protected ArmyController GetArmyController()
    {
        return GetGameController().GetPlayerModel(playerType).armyController;
    }

    protected BuildPlotController GetBuildPlotController()
    {
        return GetGameController().GetPlayerModel(playerType).buildPlotController;
    }

    protected ResourceGatheringController GetResourceGatheringController()
    {
        return GetResourceController().gatheringController;
    }
}
