using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// handles initialisation & testing of TimeTickSystem
public class TestSubscriber : MonoBehaviour
{
    [SerializeField]
    private bool outputTicksToConsole = false;
    private GameLengthClock clock;
    private CountdownClock combatClock;
    // Start is called before the first frame update
    void Start()
    {
        // move this to main game handler! for when game starts ig
        TimeTickSystem.Create();
        clock = new GameLengthClock();
        combatClock = new CountdownClock(1, 1);


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

    }
}
