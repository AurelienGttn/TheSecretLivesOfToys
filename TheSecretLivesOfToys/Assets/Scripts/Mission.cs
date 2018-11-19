using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour {
    public Text Vehicule;
    public Text InformationMission;
    private string nomVehicule;
    private string mission;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if (PanelMissions.missionTank)
        {
            nomVehicule = "tank ";
            mission = "2. Find a way to the plane";
        }

        if (PanelMissions.missionPlaneBalloon)
        {
            nomVehicule = "plane ";
            mission = "2. Explode all the balloon";
        }

        if (PanelMissions.missionFireTruck)
        {
            nomVehicule = " fire truck ";
            mission = "2. Extinguish all burning houses";
        }

        if (PanelMissions.missionPlaneRings)
        {
            nomVehicule = "plane ";
            mission = "2. Cross all the rings";
        }

        Vehicule.text = "1. Find the " + nomVehicule;
        InformationMission.text = mission;
    }

}
