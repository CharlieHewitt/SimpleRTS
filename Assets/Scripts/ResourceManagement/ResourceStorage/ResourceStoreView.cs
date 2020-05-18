using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceStoreView : MonoBehaviour
{
    public ResourceType type;
    public Text storedResources;

    public void UpdateStoredResources(string resourceAmount)
    {
        storedResources.text = resourceAmount;
    }
}
