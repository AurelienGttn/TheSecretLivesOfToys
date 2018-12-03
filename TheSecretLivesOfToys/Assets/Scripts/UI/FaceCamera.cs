using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour
{
    public Transform soldier;

    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        transform.LookAt(new Vector3(soldier.position.x, transform.position.y, soldier.position.z));
    }
}