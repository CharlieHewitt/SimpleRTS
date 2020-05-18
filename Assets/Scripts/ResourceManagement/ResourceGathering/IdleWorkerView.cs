using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdleWorkerView : MonoBehaviour
{
    public Text text;

    public void UpdateText(int num)
    {
        text.text = string.Format("Idle Workers: {0}", num.ToString());
    }
}
