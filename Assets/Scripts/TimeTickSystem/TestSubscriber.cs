using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// handles initialisation & testing of TimeTickSystem
public class TestSubscriber : MonoBehaviour
{
    private TestBuilding b;

    [SerializeField]
    private bool outputTicksToConsole = false;
    // Start is called before the first frame update
    void Start()
    {
        // move this to main game handler! for when game starts ig
        TimeTickSystem.Create();


        // event handlers for logging ticks
        if (outputTicksToConsole)
        {
            TimeTickSystem.OnTick += delegate (object sender, TimeTickSystem.OnTickEventArgs e)
            {
                Debug.Log(e.tick);
            };

            TimeTickSystem.OnTick5 += delegate (object sender, TimeTickSystem.OnTickEventArgs e)
            {
                Debug.Log("big tick");
            };
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            b = new TestBuilding(new Vector3(0, 5, 4), 30);
        }
    }
}
