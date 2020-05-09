using System.Collections;
using System.Collections.Generic;

// Note CodeLens for blame/references etc settings
public class ResourceStore
{
    public ResourceType type { get; private set; }
    public int storedResources { get; private set; }

    public ResourceStore(ResourceType type)
    {
        this.type = type;
        this.storedResources = 0;
    }

    public void PayIn(ResourceCost cost)
    {
        if (!CheckCorrectResource(cost))
        {
            // error -> wrong resource type
            return;
        }


        storedResources += cost.amount;
    }

    public void PayOut(ResourceCost cost)
    {
        if (!CheckPayOutPossible(cost) || !CheckCorrectResource(cost))
        {
            // error -> not enough resources || wrong resource type
            return;
        }

        storedResources -= cost.amount;
    }

    public bool CheckPayOutPossible(ResourceCost cost)
    {
        return storedResources > cost.amount;
    }

    public bool CheckCorrectResource(ResourceCost cost)
    {
        return cost.type == type;
    }

    public string FormattedStatusString()
    {
        return string.Format("Resource: {0} amount: {1}", type, storedResources);
    }
}
