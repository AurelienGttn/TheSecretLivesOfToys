using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Groundsensor is the cube primitive at the bottom side of our plane. 
// This primitive represents our wheels. When it has ground contact the triggered 
// variable is set to true. When not this variable is set to false, and we are in air.


public class GroundTrigger : MonoBehaviour
{

    public static bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        triggered = false;
    }
}