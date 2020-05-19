using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatCountdownClockView : MonoBehaviour
{
    public Text timerText;

    public void UpdateTime(int mins, int seconds)
    {
        timerText.text = string.Format("{0}:{1} to next combat.", mins, seconds);
    }
}
