using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDestruction : MonoBehaviour {



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "DestroyObstacle")
        {

                Destroy(collision.gameObject);

        }
    }
}
