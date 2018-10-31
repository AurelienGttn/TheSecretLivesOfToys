using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class ControlerVehicule : MonoBehaviour {

    public GameObject vehicule;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        
       


    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetButton("Fire3"))
        {
            collision.gameObject.SetActive(false);
            vehicule.GetComponent<VehiculeController>().enabled = true;
            collision.transform.GetChild(0);

        }
    }


}
