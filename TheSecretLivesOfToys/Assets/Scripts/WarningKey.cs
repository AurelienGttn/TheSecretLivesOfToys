﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningKey : MonoBehaviour {

    public GameObject missingKey; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        //Plane
        if (collision.gameObject.tag == "Player" && Key_Plane.haveKey == false && (Input.GetButton("Fire2") || Input.GetButton("F")))
        {
            missingKey.SetActive(true); 
        }
        if (collision.gameObject.tag == "Player" && Key_Plane.haveKey && (Input.GetButton("Fire2") || Input.GetButton("F")))
        {
            missingKey.SetActive(false);
        }
    }


}
