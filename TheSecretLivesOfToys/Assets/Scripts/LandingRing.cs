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
    public GameObject bullet; 

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
        bullet.SetActive(false); 
        PanelMissions.missionPanelCompleted = true;
        crossHair.SetActive(false);
        panelMissionCompleted.SetActive(true);
        Time.timeScale = 0f; 

    }
}
