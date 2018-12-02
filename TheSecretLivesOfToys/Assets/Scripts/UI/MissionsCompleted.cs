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
	void Update ()
    {
        if (FindObjectOfType<RingManager>() != null)
        {
            nomVehicule = "Plane ";
            mission = "Rings passed: " + RingManager.ringsDone.ToString() + "/" + RingManager.ringCount.ToString() + "\nLanded on the bed";
        }

        else if (PanelMissions.missionFireTruck)
        {
            nomVehicule = "FireTruck ";
            mission = "Houses saved: " + HouseOnFireManager.houseSaved.ToString() + " / " + HouseOnFireManager.houseCount.ToString() + "\n" + "Bring back the firetruck"; 
        }

        else if (PanelMissions.missionTank)
        {
            nomVehicule = "Tank ";
            mission = "Found a way to the plane ";
        } 

        else if (PanelMissions.missionPlaneBalloon)
        {
            nomVehicule = "Plane ";
            mission = "Balloons exploded: " + BalloonManager.balloonsShot.ToString() + "/" + BalloonManager.balloonCount.ToString() 
                + "\nLanded on the bed"; 
        }

        Vehicule.color = new Color32(27, 183, 27, 255);
        InformationMission.color = new Color32(27, 183, 27, 255);
        Vehicule.text = "Found "+ nomVehicule;
        InformationMission.text = mission;  
    }
}
