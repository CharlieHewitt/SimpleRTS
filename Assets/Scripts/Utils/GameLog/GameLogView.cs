using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogView : MonoBehaviour
{
    public Text logText;


    public void UpdateLogText(string log)
    {
        logText.text = log;
    }
}
