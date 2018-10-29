using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {
    
    public float velocityJump; 


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            collision.GetComponent<Rigidbody>().velocity = new Vector3(0,velocityJump,0);
        }
    }


}
