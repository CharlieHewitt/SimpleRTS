using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceTransactionFactory
{
    public static ResourceTransaction Create()
    {
        return new ResourceTransaction();
    }

}
