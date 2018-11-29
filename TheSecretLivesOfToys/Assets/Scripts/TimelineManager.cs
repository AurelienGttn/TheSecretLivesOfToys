using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour {

    public GameObject timelineTank, timelineAirplane, timelineFiretruck;
    public PlayableDirector cutsceneTank, cutsceneAirplane, cutsceneFiretruck;

	// Use this for initialization
	void Start () {
        cutsceneTank = timelineTank.GetComponent<PlayableDirector>();
        cutsceneAirplane = timelineAirplane.GetComponent<PlayableDirector>();
        cutsceneFiretruck = timelineFiretruck.GetComponent<PlayableDirector>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
