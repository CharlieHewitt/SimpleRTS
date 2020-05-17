using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviourCommandController : MonoBehaviour
{
    private GameBehaviourCommandQueue commandQueue;


    // Temporary --- should be moved
    public BuildPlotController buildPlotController { get; private set; }

    private void Awake()
    {
        buildPlotController = new BuildPlotController();
        commandQueue = new GameBehaviourCommandQueue();
        TimeTickSystem.OnTick += TryExecuteNextCommand;
    }

    // Event Handler for TimeTickSystem.OnTick
    public void TryExecuteNextCommand(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        commandQueue.ExecuteNextCommand();
    }

    public bool QueueUpCommand(GameBehaviourCommand command)
    {
        return commandQueue.QueueUpCommand(command);
    }

    // ---------------------------------------------------------------------------------------------------------------------
    // TEST METHODS
    public void IncreaseWorkerCommand()
    {
        QueueUpCommand(WorkerCommandFactory.CreateAddWorkerCommand(ResourceType.WOOD));
    }

    public void BuildWandShop()
    {
        QueueUpCommand(BuildingCommandFactory.CreateConstructBuildingCommand(BuildPlotLocation.NORTH_EAST, BuildingType.MAGICAL_WAND_SHOP));
    }

    public void BuildWizard()
    {
        QueueUpCommand(ArmyCommandFactory.CreateBuyUnitCommand(UnitType.WIZARD));
    }

    public void BuildSwordsman()
    {
        QueueUpCommand(ArmyCommandFactory.CreateBuyUnitCommand(UnitType.SWORDSMAN));
    }
}
