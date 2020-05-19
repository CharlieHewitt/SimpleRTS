using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildPlotView : MonoBehaviour
{
    public BuildPlotLocation location;
    public Text currentBuildingText;
    public Text underConstructionText;
    public Image buildingImage;

    public Sprite blackSmithSprite;
    public Sprite noBuildingSprite;
    public Sprite fletchersWorkshopSprite;
    public Sprite magicalWandShopSprite;

    public void UpdateCurrentBuilding(BuildingType type)
    {
        string buildingType = "None";

        switch(type)
        {
            case BuildingType.BLACKSMITHS:
                buildingType = "Blacksmiths";
                break;

            case BuildingType.FLETCHERS_WORKSHOP:
                buildingType = "Fletchers Workshop";
                break;

            case BuildingType.MAGICAL_WAND_SHOP:
                buildingType = "Magical Wand Shop";
                break;
        }

        UpdateImage(type);

        currentBuildingText.text = string.Format("Current Building:\n{0}", buildingType);
    }

    public void UpdateUnderConstruction(bool underConstruction)
    {
        underConstructionText.text = "Under construction? " + (underConstruction ? "yes": "no");
    }

    public void UpdateImage(BuildingType buildingType)
    {
        if (buildingType == BuildingType.BLACKSMITHS)
        {
            buildingImage.sprite = blackSmithSprite;
        }
        else if (buildingType == BuildingType.FLETCHERS_WORKSHOP)
        {
            buildingImage.sprite = fletchersWorkshopSprite;
        }
        else if (buildingType == BuildingType.MAGICAL_WAND_SHOP)
        {
            buildingImage.sprite = magicalWandShopSprite;
        }
        else
        {
            buildingImage.sprite = noBuildingSprite;

        }
    }

}
