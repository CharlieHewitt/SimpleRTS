using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Player Data
    private PlayerModel playerModel;
    private PlayerModel agentModel;

    // Combat Controller
    public CombatController combatController { get; private set; }

    private void Awake()
    {
        playerModel = new PlayerModel(PlayerType.PLAYER);
        agentModel = new PlayerModel(PlayerType.AI);

        combatController = new CombatController();
    }

    public PlayerModel GetPlayerModel(PlayerType playerType)
    {
        if (playerType == PlayerType.PLAYER)
        {
            return playerModel;
        }
        else
        {
            return agentModel;
        }
    }

    public bool CheckPlayerDefeat()
    {
        LogPlayerHealths();
        return GetPlayerModel(PlayerType.PLAYER).healthPoints == 0;
    }

    public bool CheckPlayerWin()
    {
        return GetPlayerModel(PlayerType.AI).healthPoints == 0;
    }

    public void LogPlayerHealths()
    {
        Debug.Log(string.Format("Health Update: Player: {0} AI: {1}", playerModel.healthPoints, agentModel.healthPoints));
    }

    public void HandleGameEnding(PlayerType winner)
    {
        if (winner == PlayerType.PLAYER)
        {
            // do victory stuff
        }
        else
        {
            // do defeat stuff
        }
    }


}
