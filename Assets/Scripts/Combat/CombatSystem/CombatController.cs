using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController
{
    private CombatScheduler combatScheduler;
    private CombatInstance combatInstance;
    private int roundNumber;

    public CombatController()
    {
        combatScheduler = new CombatScheduler();
        combatInstance = new CombatInstance();
        roundNumber = 0;

        ScheduleNextRound();
    }

    public void StartCombat()
    {
        // run combat
        PlayerCombatResult result = SimulateCombat();

        // handle results
        UpdatePlayerHealth(result);

        // Do viewy stuff



        bool gameOver = IsGameOver();

        if (!gameOver)
        {
            // Update values for next round
            IncreaseSupplyCap(10);
            IncreaseMaxWorkers(5);

            // Start timer for next round
            ScheduleNextRound();
        }
    }


    // Set up & run combat
    public PlayerCombatResult SimulateCombat()
    {
        return combatInstance.RunCombat();
    }


    public void ScheduleNextRound()
    {
        roundNumber++;
        combatScheduler.ScheduleCombatRound(roundNumber);
    }

    // Decrease player who lost their health points.
    public void UpdatePlayerHealth(PlayerCombatResult result)
    {
        if (result == PlayerCombatResult.PLAYER1_WIN)
        {
            GetGameController().GetPlayerModel(PlayerType.AI).DecreaseHealthPoints();
        }
        else if (result == PlayerCombatResult.PLAYER2_WIN)
        {
            GetGameController().GetPlayerModel(PlayerType.PLAYER).DecreaseHealthPoints();
        }
        else
        {
            // draw
        }

    }

    public void IncreaseSupplyCap(int number)
    {
        GetArmyController(PlayerType.PLAYER).IncreaseSupplyCap(number);
        GetArmyController(PlayerType.AI).IncreaseSupplyCap(number);
    }

    public void IncreaseMaxWorkers(int number)
    {
        GetResourceGatheringController(PlayerType.PLAYER).AddNewWorkers(number);
        GetResourceGatheringController(PlayerType.AI).AddNewWorkers(number);
    }

    // Check if game needs to continue
    public bool IsGameOver()
    {
        return GetGameController().CheckPlayerDefeat() || GetGameController().CheckPlayerWin();
    }


    // --------------- View related code

        // TO BE DONE 

    // --------------- Utility (controller access)

    private GameController GetGameController()
    {
       return GameObject.Find("GameController").GetComponent<GameController>();

    }

    private ArmyController GetArmyController(PlayerType playerType)
    {
        return GetGameController().GetPlayerModel(playerType).armyController;
    }
    
    private ResourceGatheringController GetResourceGatheringController(PlayerType playerType)
    {
        return GetGameController().GetPlayerModel(playerType).resourceController.gatheringController;
    }
}