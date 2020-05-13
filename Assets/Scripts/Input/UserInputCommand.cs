using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UserInputCommand
{
    // could be useful for reference/ resetting!
    private KeyCode defaultKey;

    public void Execute();
}
