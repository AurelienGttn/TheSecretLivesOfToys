﻿using System.Collections;
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
        if (FindObjectOfType<RingManager>() != null)
        //else if (PanelPlaneRings.missionPanelRings)
        {
            objectif.text = "Find Plane" + "\n" + "Rings passed: " + RingManager.ringsDone.ToString() + "/" + RingManager.ringCount.ToString() + "\nLand on the bed";
        }

        else if (PanelMissions.missionPlaneBalloon)
        {
            objectif.text = "Find the key" + "\n" + "Find the plane" + "\n" + "Balloons exploded: " + BalloonManager.balloonsShot.ToString() + "/" + BalloonManager.balloonCount.ToString();
        }

        else if (PanelMissions.missionFireTruck)
        {
            objectif.text = "Find the firetruck" + "\n" + "Houses saved : " + HouseOnFireManager.houseSaved.ToString() + " / " + HouseOnFireManager.houseCount.ToString() + "\n" + "Bring back the firetruck";
        }

        else if (PanelMissions.missionTank)
        {
            objectif.text = "Find the tank" + "\n" + "Find a way to the plane";
        }
        

    }
}
