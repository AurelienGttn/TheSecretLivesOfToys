using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiculeController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public GameObject RaycastCube;
    public GameObject ParticulesWater;

    // Control of firetruck 
    void Update()
    {
        // Rotation of the firetruck
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * 100.0f * Time.deltaTime, 0);

        if (Input.GetAxisRaw("Vertical") != 0)
            transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * 30f * Time.deltaTime);

        // Throw water if the player presses button A
        if (Input.GetButtonDown("Fire1"))
        {
            ParticulesWater.SetActive(true);
        }
        // Stop throwing water if the player no longer presses button A
        if (Input.GetButtonUp("Fire1"))
        {
            ParticulesWater.SetActive(false);

        }
        // If the player presses, draw a raycast to the house 
        if (Input.GetButton("Fire1"))
        {
            Vector3 positionCamion = new Vector3(gameObject.transform.position.x, 0f, gameObject.transform.position.z);
            Vector3 positionCube = new Vector3(RaycastCube.transform.position.x, 0f, RaycastCube.transform.position.z);
            Vector3 direction = (positionCube - positionCamion).normalized;
            Vector3 origin = RaycastCube.transform.position;
            RaycastHit hitInfo;
            float distance = 30f; // distance between the cube in the firetruck and the house 
            Physics.Raycast(origin, direction, out hitInfo, distance); // direction of the raycast
            if (hitInfo.collider != null) // if the raycast is not null
            {
                if (hitInfo.transform.gameObject.tag == "HouseOnFire") // if the house is on fire 
                {
                    hitInfo.transform.gameObject.GetComponent<PutOffFire>().onHit(); // call the fonction "onHit()" to putt the fire out 
                }
            }
        }
    }
}
