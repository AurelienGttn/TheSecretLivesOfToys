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
       
        for (int i = 0; i <= 11; i++)
        {
            Physics.IgnoreLayerCollision(9, i, false); // Reset settings.
            Physics.IgnoreLayerCollision(11, i, false); // Reset settings.
        }
        Physics.IgnoreLayerCollision(9, 9, false); // Wheels do not collide with each other.
        Physics.IgnoreLayerCollision(9, 11, false); // Wheels do not collide with MainBody.
        for (int i = 0; i <= 11; i++)
        {
            Physics.IgnoreLayerCollision(10, i, false); // Suspensions do not collide with anything.
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (LoadScene.missionTank)
        {
            nomVehicule = "tank ";
            mission = "2. Find a way to the plane";
        }

        if (LoadScene.missionPlaneBalloon)
        {
            nomVehicule = "plane ";
            mission = "2. Explode all the balloon";
        }

        if (LoadScene.missionFireTruck)
        {
            nomVehicule = " fire truck ";
            mission = "2. Extinguish all burning houses";
        }

        if (LoadScene.missionPlaneRings)
        {
            nomVehicule = "plane ";
            mission = "2. Cross all the rings";
        }

        Vehicule.text = "1. Find the " + nomVehicule;
        InformationMission.text = mission;
    }
}
