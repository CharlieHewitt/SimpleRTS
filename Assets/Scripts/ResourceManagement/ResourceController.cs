using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    public ResourceGatheringController gatheringController { get; private set; }
    public ResourceAmountView_Text resourceAmounts;

    // RESOURCESTOREMAP -> seperate class?
    private ResourceStoreMap resourceStoreMap;

    // Start is called before the first frame update
    private void Start()
    {
        gatheringController = new ResourceGatheringController();
        resourceStoreMap = new ResourceStoreMap();
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
        resourceAmounts.UpdateText(resourceStoreMap.StoredResourcesStatusString());

        // Update view
    }


    // BOOL!
    public bool PayOutTransaction(ResourceTransaction transaction)
    {
        if (resourceStoreMap.IsTransactionPossible(transaction))
        {
        resourceStoreMap.PayOutTransaction(transaction);
        resourceAmounts.UpdateText(resourceStoreMap.StoredResourcesStatusString());
            return true;
        }
        else
        {
            Debug.LogError("Transaction rejected, not enough resources");
            return false;
        }



        // Update view
    }



}

