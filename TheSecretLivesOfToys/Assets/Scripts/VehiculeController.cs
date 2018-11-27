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

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * 100.0f * Time.deltaTime, 0);

        if (Input.GetAxisRaw("Vertical") != 0)
            transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * 30f * Time.deltaTime);

        // Lancer de l'eau si le joueur appuie sur le bouton A 
        if (Input.GetButtonDown("Fire1"))
        {
            ParticulesWater.SetActive(true);
        }
        // Ne plus lancer de l'eau si le joueur n'appuie plus sur le bouton A 
        if (Input.GetButtonUp("Fire1"))
        {
            ParticulesWater.SetActive(false);

        }
        // Eteindre le feu 
        if (Input.GetButton("Fire1"))
        {
            Vector3 positionCamion = new Vector3(gameObject.transform.position.x, 0f, gameObject.transform.position.z);
            Vector3 positionCube = new Vector3(RaycastCube.transform.position.x, 0f, RaycastCube.transform.position.z);
            Vector3 direction = (positionCube - positionCamion).normalized;
            Vector3 origin = RaycastCube.transform.position;
            RaycastHit hitInfo;
            float distance = 30f;
            Physics.Raycast(origin, direction, out hitInfo, distance);
            if (hitInfo.collider != null)
            {
                if (hitInfo.transform.gameObject.tag == "HouseOnFire")
                {
                    Debug.Log("Je peux éteindre le feu");
                    hitInfo.transform.gameObject.GetComponent<PutOffFire>().onHit();
                }
            }
        }
    }
}
