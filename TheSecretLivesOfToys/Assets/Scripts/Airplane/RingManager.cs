using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingManager : MonoBehaviour {
    
    // Name of the scene we want to show after victory
 

    public static int ringCount;
    public static int ringsDone;
    public GameObject[] rings;
    public GameObject landingRing; 

	// Use this for initialization
	void Start () {
        ringCount = rings.Length;
        ringsDone = 0;
        rings[ringsDone].GetComponent<Ring>().setNextRing();
	}
    
    private void Update()
    {

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
        landingRing.SetActive(true); 
    }
}
