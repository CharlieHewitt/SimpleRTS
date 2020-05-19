using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    // Player or AI
    private PlayerType playerType;

    // Controllers
    public GameBehaviourCommandController gameBehaviourCommandController { get; private set; }
    public ResourceController resourceController { get; private set; }
    public BuildPlotController buildPlotController { get; private set; }
    public ArmyController armyController { get; private set; }
    public GameLogController gameLogController { get; private set; }

    // For CombatSystem
    public int healthPoints { get; set; }


    public PlayerModel(PlayerType playerType)
    {
        this.playerType = playerType;
        healthPoints = 3;
        InitialiseControllers();
    }

    private void InitialiseControllers()
    {
        gameBehaviourCommandController = new GameBehaviourCommandController(playerType);
        resourceController = new ResourceController(playerType);
        buildPlotController = new BuildPlotController(playerType);
        armyController = new ArmyController(playerType);
        gameLogController = new GameLogController(playerType);
    }

    public void DecreaseHealthPoints()
    {
        healthPoints--;

        GetGameController().UpdateHealthViews();
    }

    private GameController GetGameController()
    {
        return GameObject.Find("GameController").GetComponent<GameController>();
    }
}
