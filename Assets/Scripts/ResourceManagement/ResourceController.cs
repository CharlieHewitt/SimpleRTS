using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    private ResourceStore res;

    // TODO: implement the map & multiple resourceStores
    private Dictionary<ResourceType, ResourceStore> resourceStores;

    // Variables for testing
    float payInTimer = 4f;
    float payOutTimer = 7f;


    ResourceCost toBePayedIn = new ResourceCost(ResourceType.WOOD, 100);
    ResourceCost toBePayedOut = new ResourceCost(ResourceType.WOOD, 70);



    // Start is called before the first frame update
    void Start()
    {
        res = new ResourceStore(ResourceType.WOOD, 100);
    }

    // Update is called once per frame
    void Update()
    {
        payInTimer -= Time.deltaTime;
        payOutTimer -= Time.deltaTime;

        if (payInTimer <= 0f)
        {
            payInTimer = 4f;
            res.PayIn(toBePayedIn);
            OutputToConsole();
        }

        if (payOutTimer <= 0f)
        {
            payOutTimer = 7f;
            res.PayOut(toBePayedOut);
            OutputToConsole();
        }
    }


    void OutputToConsole()
    {
        Debug.Log(res.FormattedStatusString());
    }
}
