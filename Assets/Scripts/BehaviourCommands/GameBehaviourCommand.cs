using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameBehaviourCommand
{
    // do we need to store this? -> could be useful for Factory but prob not here
    protected GameBehaviourCommandType commandType;

    
    // Code that needs to be run when added to queue
    public abstract void OnCreate();

    // Code that needs to be executed -> Can subscribe to time tick system if needed!
    public abstract void Execute();

    protected void WaitForTicks(int ticks)
    {
        // Subscribe ...
    }

}
