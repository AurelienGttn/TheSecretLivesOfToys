using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PanelPlaneRings : MonoBehaviour {
    public GameObject panelMission;
    public static bool missionPanelRings = false;
    private bool showPanelMission;

    public PlayerController playerController;
    public GameObject timelineAirplane;
    public Camera cutsceneCamera;
    public Canvas blackScreen;

    private void Start()
    {
        blackScreen.enabled = false;
        showPanelMission = true;
    }

    private void Update()
    {
        if (showPanelMission)
        {
            Time.timeScale = 0;
        }
    }

    public void afficherPanel()
    {
        if (name == "Button_AcceptMission")
        {
            panelMission.SetActive(false);
            Time.timeScale = 0;
            showPanelMission = false;
            playerController.enabled = false;
            blackScreen.enabled = true;
            cutsceneCamera.enabled = true;
            timelineAirplane.SetActive(true);
            timelineAirplane.GetComponent<PlayableDirector>().Play();
            Key_Plane.haveKey = true;
        }
       if(name == "Button_TryAgain_Crash")
       {
            SceneManager.LoadScene("PlaneRings");
       }
       if(name == "Button_NextMission")
       {
            SceneManager.LoadScene("ContenuNonDispo");
       }
    }
}
