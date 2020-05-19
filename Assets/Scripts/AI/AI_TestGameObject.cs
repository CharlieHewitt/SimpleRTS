//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AI_TestGameObject : MonoBehaviour
//{
//    public CombatRoundPlanner planner;

//    private void Awake()
//    {
//        planner = new CombatRoundPlanner();
//    }

//    private void Update()
//    {
//        if(Input.GetKeyDown(KeyCode.Z))
//        {
//            BuildingModel model = planner.PlanBuilding();

//            if (model == null)
//            {
//                Debug.Log("building to be built = none");
//            }
//            else
//            {
//                Debug.Log("to be built: " + model.type);
//            }
//            //UnitMap targetArmy = planner.GenerateTargetArmy();
//            //Debug.Log(targetArmy.StatusString());

//            //planner.PopulateArmy(targetArmy);

//            //Debug.Log(planner.currentlyPlannedUnits.StatusString());
//        }
//    }
//}
