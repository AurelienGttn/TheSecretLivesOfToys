using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

    public Vector3 jumpForce;
    public float velocityJump = 10; 


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
           
            collision.GetComponent<Rigidbody>().AddForce(jumpForce, ForceMode.Impulse);
            //collision.GetComponent<Rigidbody>().velocity = new Vector3(0,velocityJump,0);
            
               /* var x = collision.GetComponent<Rigidbody>().velocity.x;
                collision.GetComponent<Rigidbody>().velocity = new Vector2(x, 0f);
                collision.GetComponent<Rigidbody>().AddForce(jumpForce, ForceMode.Impulse);*/
              

        }
    }


}
