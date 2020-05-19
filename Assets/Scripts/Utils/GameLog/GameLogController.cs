using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogController
{
    // Only the log for the player is displayed on the screen, the AI log could easily be made visible for debugging purposes
    private PlayerType playerType;
    private GameLogModel logModel;
    private GameLogView logView;

    public GameLogController(PlayerType playerType)
    {
        this.playerType = playerType;
        logModel = new GameLogModel(10);

        if (playerType == PlayerType.PLAYER)
        {
            logView = GameObject.Find("GameLog").GetComponent<GameLogView>();
        }
    }

    public void Log(string logEntry)
    {
        // update logmodel
        logModel.Push(logEntry);

        if (playerType == PlayerType.PLAYER)
        {
        // update logview
        logView.UpdateLogText(logModel.ToString());
        }

    }
}
