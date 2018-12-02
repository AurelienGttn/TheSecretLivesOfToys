using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour {

    public GameObject timelineTank, timelineAirplane, timelineFiretruck;
    public PlayableDirector cutsceneTank, cutsceneAirplane, cutsceneFiretruck;
    public Camera cutsceneCamera;
    public Canvas blackScreen;
    public PlayerController playerController;

	// Use this for initialization
	void Start () {
        cutsceneTank = timelineTank.GetComponent<PlayableDirector>();
        cutsceneAirplane = timelineAirplane.GetComponent<PlayableDirector>();
        cutsceneFiretruck = timelineFiretruck.GetComponent<PlayableDirector>();
	}
	
	// Update is called once per frame
	void Update () {
        cutsceneTank.stopped += Cutscene_stopped;
        cutsceneAirplane.stopped += Cutscene_stopped;
        cutsceneFiretruck.stopped += Cutscene_stopped;
	}

    private void Cutscene_stopped(PlayableDirector cutscene)
    {
        cutsceneCamera.enabled = false;
        blackScreen.enabled = false;
        playerController.enabled = true;
        Time.timeScale = 1f;
    }
}
