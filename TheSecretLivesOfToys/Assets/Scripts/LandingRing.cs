using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingRing : MonoBehaviour {

    public static bool airplaneBalloonsLevel = false;
    // Name of the scene we want to show after victory

    public GameObject panelMissionCompleted;
    public Camera mainCamera;
    public Camera cutSceneCamera;
    public AirplaneController airplaneController;
    public GameObject crossHair;

    private Renderer m_renderer;
	// Use this for initialization
	void Start () {
        m_renderer = GetComponent<Renderer>();
        //m_renderer.enabled = false;
        mainCamera.enabled = true;
        cutSceneCamera.enabled = false;
    }    
    
    private void Update()
    {
        
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
        Vector3 airplanePos = airplaneController.gameObject.transform.position;
        airplaneController.gameObject.transform.position = new Vector3(airplanePos.x, 22.5f, airplanePos.z);
        airplaneController.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Debug.Log(airplanePos);
        Debug.Log(airplaneController.gameObject.transform.position);
        airplaneController.gameObject.transform.rotation = Quaternion.identity;
        airplaneController.GetComponent<Animator>().enabled = false;
        airplaneController.GetComponent<Shooting>().enabled = false;
        crossHair.SetActive(false);
        panelMissionCompleted.SetActive(true);
        Time.timeScale = 0f; 

    }
}
