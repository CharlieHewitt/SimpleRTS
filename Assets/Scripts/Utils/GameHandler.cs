using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private BuildPlotController plotController;
    private ResourceController resourceController;

    // Start is called before the first frame update
    private void Awake()
    {
        plotController = new BuildPlotController();
        resourceController = new ResourceController();

        // TimeTickSystem.Create();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
