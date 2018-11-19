using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Objectifs : MonoBehaviour {

    public Text objectif;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (PanelMissions.missionTank)
        {
            objectif.text = "Find the tank" + "\n" + "Find a way to the plane";
        }

        if (PanelMissions.missionPlaneBalloon)
        {
            objectif.text = "Find the key" + "\n" + "Find Plane" + "\n" + "Balloon exploded : " + BalloonManager.balloonsShot.ToString() + "/" + BalloonManager.balloonCount.ToString();
        }

        if (PanelMissions.missionFireTruck)
        {
            objectif.text = "Find Firetruck"+"\n"+ "House Saved : " + HouseOnFireManager.houseSaved.ToString() + " / " + HouseOnFireManager.houseCount.ToString(); 
        }

        if (PanelMissions.missionPlaneRings)
        {
            objectif.text = "Find Plane" + "\n" + "Ring crossed : " + RingManager.ringsDone.ToString() + "/" + RingManager.ringCount.ToString(); 
        }

    }
}
