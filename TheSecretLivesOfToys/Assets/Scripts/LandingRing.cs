using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingRing : MonoBehaviour {

    public static bool airplaneBalloonsLevel = false;
    // Name of the scene we want to show after victory

    public GameObject panelMissionCompleted;
    public GameObject plane;
    public GameObject planeClone;
    public GameObject crosshair;
    public GameObject Ring; 

    private Renderer m_renderer;
	// Use this for initialization
	void Start () {
        m_renderer = GetComponent<Renderer>();
        m_renderer.enabled = false;
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
                StartCoroutine(WaitVictory());
                PanelMissions.missionPanelCompleted = true;
                plane.SetActive(false);
                planeClone.SetActive(true);
                crosshair.SetActive(false);
                Ring.SetActive(false); 
     
            }
        }
    }

    private IEnumerator WaitVictory()
    {
        yield return new WaitForSeconds(1f);
       
    }
}
