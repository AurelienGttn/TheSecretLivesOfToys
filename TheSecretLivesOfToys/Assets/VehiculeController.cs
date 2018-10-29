using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiculeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * 3.0f, 0);

        if (Input.GetAxisRaw("Vertical") != 0)
            transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * 1f * Time.deltaTime);
    }
}
