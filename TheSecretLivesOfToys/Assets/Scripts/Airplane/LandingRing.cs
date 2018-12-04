using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingRing : MonoBehaviour {
    // Used for handling several levels
    public static bool airplaneBalloonsLevel = false;

    public GameObject panelMissionCompleted;

    // Used to switch camera for the landing cutscene
    public Camera mainCamera;
    public Camera cutSceneCamera;

    public AirplaneController airplaneController;
    public GameObject crossHair;
    
	void Start () {
        mainCamera.enabled = true;
        cutSceneCamera.enabled = false;
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bool canLand = GetComponentInChildren<LandingCheck>().landingAuthorization;
            if (canLand)
            {
                cutSceneCamera.enabled = true;
                mainCamera.enabled = false;
                airplaneController.Land();
                StartCoroutine(WaitVictory());
            }
        }
    }

    private IEnumerator WaitVictory()
    {
        yield return new WaitForSeconds(3f);
        PanelMissions.missionPanelCompleted = true;
        airplaneController.enabled = false;

        // Due to how the controls are, the plane still moves weirdly after landing
        // so we need to fix its position and rotation to make it clean
        Vector3 airplanePos = airplaneController.gameObject.transform.position;
        airplaneController.gameObject.transform.position = new Vector3(airplanePos.x, 22.5f, airplanePos.z);
        airplaneController.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        airplaneController.gameObject.transform.rotation = Quaternion.identity;

        airplaneController.GetComponent<Animator>().enabled = false;
        airplaneController.GetComponent<Shooting>().enabled = false;
        crossHair.SetActive(false);
        cutSceneCamera.enabled = false;

        panelMissionCompleted.SetActive(true);
        Time.timeScale = 0f; 

    }
}
