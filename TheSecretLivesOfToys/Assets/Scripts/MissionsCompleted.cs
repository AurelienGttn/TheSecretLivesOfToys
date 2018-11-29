using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using  ChobiAssets.KTP; 

public class MissionsCompleted : MonoBehaviour {
    public Text Vehicule;
    public Text InformationMission; 

    private string nomVehicule;
    private string mission;
    
  
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (PanelMissions.missionFireTruck)
        {
            nomVehicule = "FireTruck ";
            mission = "House Saved : " + HouseOnFireManager.houseSaved.ToString() + " / " + HouseOnFireManager.houseCount.ToString() + "\n" + "Bring back the firetruck"; 
        }

        if (PanelMissions.missionTank)
        {
            nomVehicule = "Tank ";
            mission = "Way to the plane ";
        } 

        if (PanelMissions.missionPlaneBalloon)
        {
            nomVehicule = "Plane ";
            mission = "Balloon exploded :" + BalloonManager.balloonsShot.ToString() + "/" + BalloonManager.balloonCount.ToString() 
                + "\nLand through ring"; 
        }
        if (PanelPlaneRings.missionPanelRings)
        {
            nomVehicule = "Plane ";
            mission = "Ring crossed : " + RingManager.ringsDone.ToString() + "/" + RingManager.ringCount.ToString();
        }

        Vehicule.text = "Find "+ nomVehicule + ": ";
        InformationMission.text = mission;  
    }
}
