using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviourCommandController
{
    private PlayerType playerType;
    private GameBehaviourCommandQueue commandQueue;

    public GameBehaviourCommandController(PlayerType playerType)
    {
        this.playerType = playerType;
        commandQueue = new GameBehaviourCommandQueue();
        TimeTickSystem.OnTick += TryExecuteNextCommand;
    }


    // Event Handler for TimeTickSystem.OnTick
    public void TryExecuteNextCommand(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        commandQueue.ExecuteNextCommand();
    }

    public void QueueUpCommand(GameBehaviourCommand command)
    {
        commandQueue.QueueUpCommand(command);
    }

    // ---------------------------------------------------------------------------------------------------------------------
    // UI TEST METHODS -> need to be removed
    //public void IncreaseWorkerCommand()
    //{
    //    QueueUpCommand(WorkerCommandFactory.CreateAddWorkerCommand(ResourceType.WOOD));
    //}

    //public void BuildWandShop()
    //{
    //    QueueUpCommand(BuildingCommandFactory.CreateConstructBuildingCommand(BuildPlotLocation.NORTH_EAST, BuildingType.MAGICAL_WAND_SHOP));
    //}

    //public void BuildWizard()
    //{
    //    QueueUpCommand(ArmyCommandFactory.CreateBuyUnitCommand(UnitType.WIZARD));
    //}

    //public void BuildSwordsman()
    //{
    //    QueueUpCommand(ArmyCommandFactory.CreateBuyUnitCommand(UnitType.SWORDSMAN));
    //}
}
