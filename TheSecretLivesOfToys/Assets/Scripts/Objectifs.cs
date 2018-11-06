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
		if (SceneManager.GetActiveScene().name == "FireTruck")
        {
            objectif.text = "Find Firetruck"+"\n"+ "House Saved : " + PutOffFire.HouseSaved.ToString() + " / " + PutOffFire.HouseOnFire.ToString(); 
        }

        if (SceneManager.GetActiveScene().name == "PlaneLevel1")
        {
            objectif.text = "Find Plane" + "\n" + "Ring crossed :" + RingManager.ringsDone.ToString() + "/" + RingManager.ringCount.ToString(); 
        }

        if (SceneManager.GetActiveScene().name == "Tank")
        {
            objectif.text = "Find Tank" + "\n" + "Demolished objects : 10/10";
        }


    }
}
