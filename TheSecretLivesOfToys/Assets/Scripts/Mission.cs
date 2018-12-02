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
            nomVehicule = "tank";
            mission = "2. Find a way to the plane";
        }

        if (PanelMissions.missionPlaneBalloon)
        {
            nomVehicule = "key"; 
            mission = "2. Find the plane \n3. Explode all the balloons";
        }

        if (PanelMissions.missionFireTruck)
        {
            nomVehicule = "firetruck";
            mission = "2. Extinguish all burning houses \n3. Bring back the firetruck ";
        }

        Vehicule.text = "1. Find the " + nomVehicule;
        InformationMission.text = mission;
    }

}
