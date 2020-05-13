using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputController : MonoBehaviour
{
    private UserInputCommandMap commandMap;

    private void Awake()
    {
        commandMap = new UserInputCommandMap();
    }

    private void Update()
    {
        // Only do this when the user presses a key
        if (Input.anyKey)
        {
            // iterate through keys that have a command assigned to them & run the associated command
            foreach (KeyCode key in commandMap.Keys())
            {
                if (Input.GetKeyDown(key))
                {
                    commandMap.RunUserInputCommand(key);
                }
            }

        }
    }
}
