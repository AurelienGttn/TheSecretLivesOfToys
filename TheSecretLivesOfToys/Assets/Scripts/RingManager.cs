using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingManager : MonoBehaviour {

    public static bool airplaneRingsLevel = false;
    // Name of the scene we want to show after victory
    private string victoryScene = "PlaneScene";

    public static int ringCount;
    public static int ringsDone;
    public GameObject[] rings;

	// Use this for initialization
	void Start () {
        ringCount = rings.Length;
        ringsDone = 0;
        rings[ringsDone].GetComponent<Ring>().setNextRing();
	}

    // Method called when player goes through a ring
    public void AddRingDone()
    {
        ringsDone++;
        if (ringsDone < ringCount)
        {
            rings[ringsDone].GetComponent<Ring>().setNextRing();
        }
        else
            Victory();
    }
    void Victory()
    {
        airplaneRingsLevel = true;
        SceneManager.LoadScene(victoryScene);
    }
}
