using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationFiretruck : MonoBehaviour {
    public GameObject missionPanelCompleted; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Call when the firetruck enter in the station 
    public void OnTriggerEnter(Collider other)
    {
        // if the object is the firetruck and all the house have been saved  
        if (other.gameObject.tag == "FireTruck" && HouseOnFireManager.houseSaved == HouseOnFireManager.houseCount)
        {
            Time.timeScale = 0f; // Freeze time 
            PanelMissions.missionPanelCompleted = true; 
            missionPanelCompleted.SetActive(true); // Display the panel mission completed 
        }

    }
}
