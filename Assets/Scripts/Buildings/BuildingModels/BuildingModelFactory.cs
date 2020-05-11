using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingModelFactory
{
    public static BuildingModel Create(BuildingType type)
    {
        switch(type)
        {
            case BuildingType.BLACKSMITHS:
                return new BlacksmithsModel();

            case BuildingType.FLETCHERS_WORKSHOP:
                return new FletchersWorkshopModel();

            case BuildingType.MAGICAL_WAND_SHOP:
                return new MagicalWandShopModel();

            default:
                Debug.LogError(string.Format("No BuildingModel has been implemented for {0}", type));
                return null;
        }
    }

}
