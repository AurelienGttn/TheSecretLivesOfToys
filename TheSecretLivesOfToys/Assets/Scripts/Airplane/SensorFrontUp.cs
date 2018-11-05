using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sensor front up is part of the driving behaviour to keep the airplane aligned with the ground

public class SensorFrontUp : MonoBehaviour
{

    public static bool sensorFrontUp = false;

    private void OnTriggerEnter(Collider other)
    {
        sensorFrontUp = true;
    }

    private void OnTriggerExit(Collider other)
    {
        sensorFrontUp = false;
    }
}