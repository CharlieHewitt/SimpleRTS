using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatResultView : MonoBehaviour
{
    // outcome
    public Text outcomeText;
    public Image outcomeImage;


    // unit Number thingies
    public Dictionary<UnitType, UnitCombatResultView> playerUnitViews;
    public Dictionary<UnitType, UnitCombatResultView> aiUnitViews;

    private void Awake()
    {
        outcomeText = GameObject.Find("CombatOutcomeText").GetComponent<Text>();
        outcomeImage = GameObject.Find("CombatOutcome").GetComponent<Image>();

        InitialisePlayerUnitViews();
        InitialiseAIUnitViews();
        //HideWindow();
    }

    public void InitialisePlayerUnitViews()
    {
        playerUnitViews = new Dictionary<UnitType, UnitCombatResultView>();

        playerUnitViews[UnitType.SWORDSMAN] = GameObject.Find("Player - Swordsman").GetComponent<UnitCombatResultView>();
        playerUnitViews[UnitType.ARCHER] = GameObject.Find("Player - Archer").GetComponent<UnitCombatResultView>();
        playerUnitViews[UnitType.WIZARD] = GameObject.Find("Player - Wizard").GetComponent<UnitCombatResultView>();
    }

    public void InitialiseAIUnitViews()
    {
        aiUnitViews = new Dictionary<UnitType, UnitCombatResultView>();

        aiUnitViews[UnitType.SWORDSMAN] = GameObject.Find("AI - Swordsman").GetComponent<UnitCombatResultView>();
        aiUnitViews[UnitType.ARCHER] = GameObject.Find("AI - Archer").GetComponent<UnitCombatResultView>();
        aiUnitViews[UnitType.WIZARD] = GameObject.Find("AI - Wizard").GetComponent<UnitCombatResultView>();
    }

    public void ShowWindow()
    {
        this.gameObject.SetActive(true);
    }

    public void HideWindow()
    {
        this.gameObject.SetActive(false);
    }

    public void UpdateCombatResultView(ActiveUnits playerUnits, ActiveUnits aiUnits)
    {
        UpdatePlayerUnitViews(playerUnits);
        UpdateAIUnitViews(aiUnits);
    }

    public void UpdatePlayerUnitViews(ActiveUnits playerUnits)
    {
        UnitMap p_startingUnits = playerUnits.GetStartingUnits();
        UnitMap p_casualties = playerUnits.GetUnitLosses();

        foreach (KeyValuePair<UnitType, UnitCombatResultView> entry in playerUnitViews)
        {
            int startingNum = p_startingUnits.GetNumber(entry.Key);
            int casualties = p_casualties.GetNumber(entry.Key);

            entry.Value.UpdateNumUnits(startingNum, casualties);
        }
    }

    public void UpdateAIUnitViews(ActiveUnits aiUnits)
    {
        UnitMap ai_startingUnits = aiUnits.GetStartingUnits();
        UnitMap ai_casualties = aiUnits.GetUnitLosses();

        foreach (KeyValuePair<UnitType, UnitCombatResultView> entry in aiUnitViews)
        {
            int startingNum = ai_startingUnits.GetNumber(entry.Key);
            int casualties = ai_casualties.GetNumber(entry.Key);

            entry.Value.UpdateNumUnits(startingNum, casualties);
        }
    }

    public void UpdateOutcome(PlayerCombatResult result)
    {
        if (result == PlayerCombatResult.PLAYER1_WIN)
        {
            outcomeText.text = "Victory";
        }
        else if (result == PlayerCombatResult.PLAYER2_WIN)
        {
            outcomeText.text = "Defeat";
        }
        else
        {
            outcomeText.text = "Draw";
        }
    }

}
