using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sensor rear is part of the driving behaviour to keep the airplane aligned with the ground

public class SensorRear : MonoBehaviour
{

    public static bool sensorRear = false;

    private void OnTriggerEnter(Collider other)
    {
        sensorRear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        sensorRear = false;
    }
}