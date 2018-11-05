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
            Vehicule.name = "Text_FireTruck"; 
        }

        if (Damage_Control_CS.TankScene)
        {
            Vehicule.name = "Text_Tank";
        } 
            
         if(AirplaneController.PlaneScene)
         {
             Vehicule.name = "Text_Plane";
         }

        if (Vehicule.name == "Text_FireTruck")
        {
            nomVehicule = "FireTruck ";
            mission = "House Saved : " + PutOffFire.HouseSaved.ToString() + "/" + PutOffFire.HouseOnFire.ToString();
        }

        if (Vehicule.name == "Text_Tank")
        {
            nomVehicule = "Tank ";
            mission = "Demolished objects : 10/10";
        }

        if (Vehicule.name == "Text_Plane")
        {
            nomVehicule = "Plane ";
            mission = "Ring crossed : 4/4";  
        }

        Vehicule.text = "Find "+ nomVehicule + ": ";
        InformationMission.text = mission;  
    }
}
