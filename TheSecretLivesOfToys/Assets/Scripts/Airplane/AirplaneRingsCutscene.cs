using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class AirplaneRingsCutscene : MonoBehaviour
{
    private PlayableDirector cutscene;
    public Camera cutsceneCamera;
    public PlayerController playerController;

    public GameObject objectifs, timer;

    // Use this for initialization
    void Start()
    {
        cutscene = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        cutscene.stopped += Cutscene_stopped;
    }

    private void Cutscene_stopped(PlayableDirector cutscene)
    {
        cutsceneCamera.enabled = false;
        playerController.enabled = true;
        objectifs.SetActive(true);
        timer.SetActive(true);
        Time.timeScale = 1f;
    }
}
