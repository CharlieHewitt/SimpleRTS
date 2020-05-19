using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfoView : MonoBehaviour
{
    // to get selected plot!
    public SelectedBuildPlotManager selectedBuildPlotManager;

    public BuildingType buildingType;

    public Text constructionCost;
    public Image buildingImage;

    public bool showConstructButton;
    public Button constructButton;
    public Button demolishButton;

    private void Awake()
    {
        showConstructButton = true;
        ShowCorrectButton();
    }

    public void UpdateConstructionCost(BuildingType type)
    {
        BuildingModel model = BuildingModelFactory.Create(type);
        buildingType = model.type;
        string wood = model.buildCost.TransactionStatusString(ResourceType.WOOD);
        string magicStone = model.buildCost.TransactionStatusString(ResourceType.MAGIC_STONE);
        string buildTime = (model.constructionTime / 5).ToString() + "s";

        constructionCost.text = string.Format("Wood: {0}\nMagic Stone: {1}\nBuild Time: {2}", wood, magicStone, buildTime);
    }

    public void UpdateIsBuilt(bool isBuilt)
    {
        showConstructButton = !isBuilt;
        ShowCorrectButton();
    }

    public void ShowCorrectButton()
    {
        if (showConstructButton)
        {
            demolishButton.gameObject.SetActive(false);
            constructButton.gameObject.SetActive(true);
        }
        else
        {
            demolishButton.gameObject.SetActive(true);
            constructButton.gameObject.SetActive(false);
        }
    }

    public void QueueBuildCommand()
    {
        BuildPlotLocation location = selectedBuildPlotManager.GetSelectedLocation();
        GameBehaviourCommand command = BuildingCommandFactory.CreateConstructBuildingCommand(location, buildingType, PlayerType.PLAYER);
        QueueUpCommand(command);
    }

    public void QueueDemolishCommand()
    {
        // Get plot that contains building
        Dictionary<BuildPlotLocation, BuildPlot> buildPlots = GetBuildPlotController().buildPlotMap.buildPlots;
        foreach (BuildPlotLocation plotLocation in buildPlots.Keys)
        {
            if (GetBuildPlotController().buildPlotMap.GetBuilding(plotLocation) == buildingType)
            {
                GameBehaviourCommand command = BuildingCommandFactory.CreateDemolishCommand(plotLocation, PlayerType.PLAYER);
                QueueUpCommand(command);
            }
        }
    }

    private void QueueUpCommand(GameBehaviourCommand command)
    {
        GetGameBehaviourCommandController().QueueUpCommand(command);
    }


    // Utility -- Controller access

    private GameController GetGameController()
    {
        return GameObject.Find("GameController").GetComponent<GameController>();

    }

    private BuildPlotController GetBuildPlotController()
    {
        return GetGameController().GetPlayerModel(PlayerType.PLAYER).buildPlotController;
    }

    private GameBehaviourCommandController GetGameBehaviourCommandController()
    {
        return GetGameController().GetPlayerModel(PlayerType.PLAYER).gameBehaviourCommandController;
    }

}
