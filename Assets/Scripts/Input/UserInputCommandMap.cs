using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a wrapper controlling access to a map of <KeyCode, UserInputCommand>
public class UserInputCommandMap
{
    private Dictionary<KeyCode, UserInputCommand> inputCommands;

    public UserInputCommandMap()
    {
        inputCommands = new Dictionary<KeyCode, UserInputCommand>();
        SetToDefault();
    }

    public void RunUserInputCommand(KeyCode keycode)
    {
        inputCommands[keycode].Execute();
    }

    public Dictionary<KeyCode, UserInputCommand>.KeyCollection Keys()
    {
        return inputCommands.Keys;
    }

    public void SetToDefault()
    {
        // TODO once commands are implemented!
        AddInputCommand(KeyCode.Q, null);
        
        // eventually read these from json so these could be stored locally in different "setups"
    }

    private void AddInputCommand(KeyCode key, UserInputCommand command)
    {
        inputCommands.Add(key, command);
    }


}

