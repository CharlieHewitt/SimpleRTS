using System.Collections;
using System.Collections.Generic;

public class ResourceStore
{
    public ResourceType type { get; private set; }
    public int storedResources { get; private set; }

    public ResourceStore(ResourceType type, int initialResourceAmount)
    {
        this.type = type;
        this.storedResources = initialResourceAmount;
    }

    public void PayIn(ResourceCost cost)
    {
        if (!CheckCorrectResource(cost))
        {
            // error
            return;
        }


        storedResources += cost.amount;
    }

    public void PayOut(ResourceCost cost)
    {
        if (!CheckPayOutPossible(cost) || !CheckCorrectResource(cost))
        {
            // error
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
