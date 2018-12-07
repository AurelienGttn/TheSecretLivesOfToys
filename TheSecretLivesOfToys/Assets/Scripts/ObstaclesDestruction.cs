using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDestruction : MonoBehaviour {

    
    public GameObject explosionEffect;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "DestroyObstacle")
        {
            Instantiate(explosionEffect, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            collision.gameObject.GetComponent<Destruction>().SpawnDestroy(); 
            Destroy(collision.gameObject);

        }
    }
}
