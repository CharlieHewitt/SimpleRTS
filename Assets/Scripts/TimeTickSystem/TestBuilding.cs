using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBuilding
{
    public GameObject gameObject;
    private int buildTick;
    private int buildTickMax;
    private bool isConstructing;

    public TestBuilding(Vector3 position, int ticksToContruct)
    {
        gameObject = new GameObject("Bob The Builder");
        // add sprite etc
        gameObject.transform.position = position;

        buildTick = 0;
        buildTickMax = ticksToContruct;
        isConstructing = true;

        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
    }

    // event handler to deal with TimeTickSystem
    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if (isConstructing)
        {
            buildTick += 1;

            float buildTickNormalized = buildTick * 1f / buildTickMax; 
            
            if (buildTickNormalized >= 0.3)
            {
                Debug.Log(">30% done");
            }

            if (buildTick >= buildTickMax)
            {
                isConstructing = false;
                UnSubscribe();
            }
            else
            {
                Debug.Log(string.Format("building {0} / {1} ({2}%)", buildTick, buildTickMax, buildTickNormalized*100));
            }


        }
    }

    private void UnSubscribe()
    {
        TimeTickSystem.OnTick -= TimeTickSystem_OnTick;
        Debug.Log("unsubscribed");
    }

}
