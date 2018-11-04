using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingManager : MonoBehaviour {

    public static bool airplaneRingsLevel = false;
    private string victoryScene = "PlaneScene";

    public static int ringsCount;
    public static int ringsDone;
    public GameObject[] rings;

	// Use this for initialization
	void Start () {
        //rings = GameObject.FindGameObjectsWithTag("Ring");
        ringsCount = rings.Length;
        ringsDone = 0;
        rings[ringsDone].GetComponent<Ring>().setNextRing();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //rings[ringsDone].GetComponent<Ring>().setNextRing();
        // Victory condition
        //if (ringsDone == ringsCount)
        //    Victory();
	}

    // Method called when player goes through a ring
    public void AddRingDone()
    {
        ringsDone++;
        if (ringsDone < ringsCount)
        {
            Debug.Log("Ring " + ringsDone + " says: I'm next!");
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
