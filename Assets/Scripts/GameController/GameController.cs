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

    // AI
    public AI_Agent ai_agent { get; private set; }

    // HealthViews
    public HealthView playerHealthView;
    public HealthView aiHealthView;
    public GameLengthClock clock;


    private void Awake()
    {
        clock = new GameLengthClock();
        playerModel = new PlayerModel(PlayerType.PLAYER);
        agentModel = new PlayerModel(PlayerType.AI);
        ai_agent = new AI_Agent();
        combatController = new CombatController();
        InitialiseHealthViews();
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

    private void InitialiseHealthViews()
    {
        playerHealthView = GameObject.Find("PlayerHealthView").GetComponent<HealthView>();
        aiHealthView = GameObject.Find("AIHealthView").GetComponent<HealthView>();
        UpdateHealthViews();
    }

    public void UpdateHealthViews()
    {
        playerHealthView.UpdateHealth(GetPlayerModel(PlayerType.PLAYER).healthPoints);
        aiHealthView.UpdateHealth(GetPlayerModel(PlayerType.AI).healthPoints);
    }


}
