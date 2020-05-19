using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogModel
{
    private List<string> log;
    private int maxLogMessages;
    public GameLogModel(int maxSize)
    {
        maxLogMessages = maxSize;
        log = new List<string>();
    }

    public void Push(string logMessage)
    {
        if (log.Count == maxLogMessages)
        {
            log.RemoveAt(0);
        }

        log.Add(logMessage);
    }

    public override string ToString()
    {
        string output = "";
        foreach (string logMessage in log)
        {
            output += logMessage + "\n";
        }

        return output;
    }   

    private GameController GetGameController()
    {
        return GameObject.Find("GameController").GetComponent<GameController>();
    }
}
