using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingRing : MonoBehaviour {

    public static bool airplaneBalloonsLevel = false;
    // Name of the scene we want to show after victory
    private string victoryScene = "MissionCompleted";

    private Renderer m_renderer;
	// Use this for initialization
	void Start () {
        m_renderer = GetComponent<Renderer>();
        m_renderer.enabled = false;
    }    
    
    // A enlever, test menu
    private void Update()
    {

        if (Input.GetButton("E"))
        {
            airplaneBalloonsLevel = true;
            SceneManager.LoadScene(victoryScene);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(WaitVictory());
        }
    }

    private IEnumerator WaitVictory()
    {
        yield return new WaitForSeconds(2f);

        airplaneBalloonsLevel = true;
        SceneManager.LoadScene(victoryScene);
    }
}
