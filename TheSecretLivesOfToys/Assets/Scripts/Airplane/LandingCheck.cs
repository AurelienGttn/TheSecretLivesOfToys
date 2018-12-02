using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingCheck : MonoBehaviour {

    public bool landingAuthorization;

	// Use this for initialization
	void Start () {
        landingAuthorization = false;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            landingAuthorization = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            landingAuthorization = false;
        }
    }
}
