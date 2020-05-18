using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManagementView : MonoBehaviour
{
    public Text text;
    public ResourceType resourceType;

    public void UpdateText(int num)
    {
        text.text = string.Format("Workers: {0}",num.ToString());
    }

    public void AddWorker()
    {
      GameBehaviourCommand command = WorkerCommandFactory.CreateAddWorkerCommand(resourceType);
      QueueUpCommand(command);
    }

    public void RemoveWorker()
    {
        GameBehaviourCommand command = WorkerCommandFactory.CreateRemoveWorkerCommand(resourceType);
        QueueUpCommand(command);
    }

    private void QueueUpCommand(GameBehaviourCommand command)
    {
        GameObject.Find("GameBehaviourController").GetComponent<GameBehaviourCommandController>().QueueUpCommand(command);
    }




    // These exist due to the unfortunate outcome of the 
}
