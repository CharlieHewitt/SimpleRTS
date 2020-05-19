using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    public PlayerType playerType;
    public Text healthText;

    public void UpdateHealth(int health)
    {
        if (PlayerType.PLAYER == playerType)
        {
            string text = health.ToString() + " (You)";
            healthText.text = text;
        }
        else
        {
            string text = health.ToString() + " (AI)";
            healthText.text = text;
        }
    }
}
