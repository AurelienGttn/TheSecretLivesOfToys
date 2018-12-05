using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {
    
    public float velocityJump;

    private void OnTriggerEnter(Collider other) // call when we jump into the spring 
    {
        if (other.gameObject.tag == "Player")
        {
            Animator animator = other.GetComponent<Animator>();
            Vector3 currentVelocity = other.GetComponent<Rigidbody>().velocity;
            other.GetComponent<Rigidbody>().velocity = new Vector3(10 * Time.deltaTime , velocityJump, 10 * Time.deltaTime); // velocity to jump 
            other.GetComponent<PlayerController>().isJumping = true;
            animator.SetFloat("Speed", 0); 
            animator.SetTrigger("Jump"); // play the animation of jump
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().isJumping = true;
        }
    }


}
