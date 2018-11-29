using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelPlaneRings : MonoBehaviour {
    public GameObject panelMission;
    public static bool missionPanelRings = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void afficherPanel()
    {
        if (this.name == "Button_AcceptMission")
        {
            Time.timeScale = 1f; 
            panelMission.SetActive(false);
        }
       if(this.name == "Button_TryAgain_Crash")
       {
            SceneManager.LoadScene("PlaneRings");
       }
       if(this.name == "Button_NextMission")
       {
            SceneManager.LoadScene("ContenuNonDispo");
       }
    }
}
