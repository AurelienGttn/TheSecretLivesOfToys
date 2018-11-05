using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sensor front is part of the driving behaviour to keep the airplane aligned with the ground

public class SensorFront : MonoBehaviour { 

    public static bool sensorFront = false;

    private void OnTriggerEnter(Collider other) {
        sensorFront = true;
    }

    private void OnTriggerExit(Collider other) {
        sensorFront = false;
    }
}