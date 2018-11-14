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

        if (PutOffFire.FireTruckScene)
        {
            nomVehicule = "FireTruck ";
            mission = "House Saved : " + PutOffFire.HouseSaved.ToString() + "/" + PutOffFire.HouseOnFire.ToString();
        }

        if (Damage_Control_CS.TankScene)
        {
            nomVehicule = "Tank ";
            mission = "You found the plane ";
        } 
            
         if(RingManager.airplaneRingsLevel)
         {
            nomVehicule = "Plane ";
            mission = "Ring crossed :" + RingManager.ringsDone.ToString() + "/" + RingManager.ringCount.ToString();
         }

        if (BalloonManager.airplaneBalloonsLevel)
        {
            nomVehicule = "Plane ";
            mission = "Balloon exploded :" + BalloonManager.balloonsShot.ToString() + "/" + BalloonManager.balloonCount.ToString(); 
        }

        Vehicule.text = "Find "+ nomVehicule + ": ";
        InformationMission.text = mission;  
    }
}
