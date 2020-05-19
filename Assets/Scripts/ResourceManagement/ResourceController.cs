using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceController
{
    private PlayerType playerType;

    public ResourceGatheringController gatheringController { get; private set; }

    private ResourceStoreMap resourceStoreMap;

    // views
    private Dictionary<ResourceType, ResourceStoreView> resourceStoreViews;

    // Start is called before the first frame update
    public ResourceController(PlayerType playerType)
    {
        this.   playerType = playerType;
        gatheringController = new ResourceGatheringController(playerType);
        resourceStoreMap = new ResourceStoreMap();


        InitialiseResourceStoreViews();
        UpdateResourceStoreViews();
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
    }

    public bool IsTransactionPossible(ResourceTransaction transaction)
    {
        return resourceStoreMap.IsTransactionPossible(transaction);
    }



    // -------- View related code -------------------
    // should only be called when PlayerType = PLAYER

    private void InitialiseResourceStoreViews()
    {
        if (playerType == PlayerType.AI)
        {
            return;
        }

        resourceStoreViews = new Dictionary<ResourceType, ResourceStoreView>();

        resourceStoreViews[ResourceType.WOOD] = GameObject.Find("Wood ResourceStoreView").GetComponent<ResourceStoreView>();
        resourceStoreViews[ResourceType.MAGIC_STONE] = GameObject.Find("MagicStone ResourceStoreView").GetComponent<ResourceStoreView>();
    }

    private void UpdateResourceStoreViews()
    {
        if (playerType == PlayerType.AI)
        {
            return;
        }

        resourceStoreViews[ResourceType.WOOD].UpdateStoredResources(resourceStoreMap.GetStoredResources(ResourceType.WOOD));
        resourceStoreViews[ResourceType.MAGIC_STONE].UpdateStoredResources(resourceStoreMap.GetStoredResources(ResourceType.MAGIC_STONE));
    }

}

// --------- Legacy code


// Update is called once per frame
//private void Update()
//{
//    // tests for workers -> write automated ones!
//    if (Input.GetKeyDown(KeyCode.Q))
//    {
//        gatheringController.AddWorker(ResourceType.WOOD);
//    }
//    else if (Input.GetKeyDown(KeyCode.W))
//    {
//        gatheringController.RemoveWorker(ResourceType.WOOD);

//    }
//    else if (Input.GetKeyDown(KeyCode.A))
//    {
//        gatheringController.AddWorker(ResourceType.MAGIC_STONE);
//    }
//    else if (Input.GetKeyDown(KeyCode.S))
//    {
//        gatheringController.RemoveWorker(ResourceType.MAGIC_STONE);
//    }
//}
