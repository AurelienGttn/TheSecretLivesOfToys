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

        if (LoadScene.firstMission)
        {
            Vehicule.name = "Text_FireTruck"; 
        }

        if (LoadScene.missionTank)
        {
            Vehicule.name = "Text_Tank";
        }

        if (LoadScene.missionPlane)
        {
            Vehicule.name = "Text_Plane";
        }


        if (Vehicule.name == "Text_FireTruck")
        {
            nomVehicule = " fire truck ";
            mission = "2. Extinguish all burning houses"; 
        }

        if (Vehicule.name == "Text_Plane")
        {
            nomVehicule = "plane ";
            mission = "2. Cross all the rings";
        }

        if (Vehicule.name == "Text_Tank")
        {
            nomVehicule = "tank ";
            mission = "2. Destroy all objects on your way";
        }


        Vehicule.text = "1. Find the " + nomVehicule;
        InformationMission.text = mission;
    }
}
