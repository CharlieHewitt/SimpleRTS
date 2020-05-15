using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceAmountView_Text : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
       // text = GameObject.Find("User Interface").GetComponent<Canvas>().GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void UpdateText(string newText)
    {
        text.text = newText;
    }
}
