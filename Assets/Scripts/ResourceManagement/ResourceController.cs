using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    public ResourceGatheringController gatheringController { get; private set; }

    private ResourceStoreMap resourceStoreMap;

    // views
    private Dictionary<ResourceType, ResourceStoreView> resourceStoreViews;

    // Start is called before the first frame update
    private void Start()
    {
        gatheringController = new ResourceGatheringController();
        resourceStoreMap = new ResourceStoreMap();
        InitialiseResourceStoreViews();
        UpdateResourceStoreViews();
    }

    // Update is called once per frame
    private void Update()
    {
        // tests for workers -> write automated ones!
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gatheringController.AddWorker(ResourceType.WOOD);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            gatheringController.RemoveWorker(ResourceType.WOOD);

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            gatheringController.AddWorker(ResourceType.MAGIC_STONE);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            gatheringController.RemoveWorker(ResourceType.MAGIC_STONE);
        }
    }


    /** 
     *  Error handling on these + these will be called by commands!
     */

    public void PayInTransaction(ResourceTransaction transaction)
    {
        resourceStoreMap.PayInTransaction(transaction);
        UpdateResourceStoreViews();

        // Update view
    }


    // BOOL!
    public bool PayOutTransaction(ResourceTransaction transaction)
    {
        bool success = false;
        if (resourceStoreMap.IsTransactionPossible(transaction))
        {
            resourceStoreMap.PayOutTransaction(transaction);
            success = true;
            UpdateResourceStoreViews();
        }
        else
        {
            Debug.LogError("Transaction rejected, not enough resources");
        }

        return success;



        // Update view
    }



    // View related code

    private void InitialiseResourceStoreViews()
    {
        resourceStoreViews = new Dictionary<ResourceType, ResourceStoreView>();

        resourceStoreViews[ResourceType.WOOD] = GameObject.Find("Wood ResourceStoreView").GetComponent<ResourceStoreView>();
        resourceStoreViews[ResourceType.MAGIC_STONE] = GameObject.Find("MagicStone ResourceStoreView").GetComponent<ResourceStoreView>();
    }

    private void UpdateResourceStoreViews()
    {
        resourceStoreViews[ResourceType.WOOD].UpdateStoredResources(resourceStoreMap.GetStoredResources(ResourceType.WOOD));
        resourceStoreViews[ResourceType.MAGIC_STONE].UpdateStoredResources(resourceStoreMap.GetStoredResources(ResourceType.MAGIC_STONE));
    }

}

