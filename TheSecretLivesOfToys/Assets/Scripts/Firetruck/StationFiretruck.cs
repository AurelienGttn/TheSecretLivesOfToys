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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireTruck" && HouseOnFireManager.houseSaved == HouseOnFireManager.houseCount)
        {
            Time.timeScale = 0f;
            PanelMissions.missionPanelCompleted = true; 
            missionPanelCompleted.SetActive(true);
        }

    }
}
