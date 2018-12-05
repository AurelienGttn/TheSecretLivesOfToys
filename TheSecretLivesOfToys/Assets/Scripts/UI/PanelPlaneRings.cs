using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PanelPlaneRings : MonoBehaviour {
    public GameObject panelMission;
    public static bool missionPanelRings = true;
    private bool showPanelMission;

    public GameObject objectifs;
    public GameObject timer;

    public PlayerController playerController;
    public GameObject timelineAirplane;
    public Camera cutsceneCamera;

    public AudioSource globalMusic;

    private void Start()
    {
        objectifs.SetActive(false);
        timer.SetActive(false);
        showPanelMission = true;
    }

    private void Update()
    {
        if (showPanelMission)
        {
            Time.timeScale = 0;
        }
    }

    // There are many things to enable/disable when we start the mission plane rings 
    // such as disable objectifs and panel to show the cinematic 
    public void afficherPanel()
    {
        if (name == "Button_AcceptMission")
        {
            globalMusic.Play();
            panelMission.SetActive(false);
            Time.timeScale = 0;
            showPanelMission = false;
            playerController.enabled = false;
            cutsceneCamera.enabled = true;
            timelineAirplane.SetActive(true);
            timelineAirplane.GetComponent<PlayableDirector>().Play();
            Key_Plane.haveKey = true;
        }
        // Restart the scene when the plane crash 
       if(name == "Button_TryAgain_Crash")
       {
            SceneManager.LoadScene("PlaneRings");
       }
       // Load scene "ContenuNonDispo" when the player click on the button "next mission"
       if(name == "Button_NextMission")
       {
            SceneManager.LoadScene("ContenuNonDispo");
       }
    }
}
