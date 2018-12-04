using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {
    
    public float velocityJump;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Animator animator = other.GetComponent<Animator>();
            Vector3 currentVelocity = other.GetComponent<Rigidbody>().velocity;
            other.GetComponent<Rigidbody>().velocity = new Vector3(10 * Time.deltaTime , velocityJump, 10 * Time.deltaTime);
            other.GetComponent<PlayerController>().isJumping = true;
            animator.SetFloat("Speed", 0);
            animator.SetTrigger("Jump");
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
