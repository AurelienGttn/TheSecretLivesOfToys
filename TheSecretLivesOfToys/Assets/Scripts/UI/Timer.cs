using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Timer : MonoBehaviour {
    public Text timerText;
    private float startTime;
    private GameObject panels; 

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        
	}
	
	// Update is called once per frame
	void Update () {
        float t = Time.time - startTime;
        timerText.text = string.Format("{0:00}:{1:00}", Mathf.Floor(t / 60), t % 60);
		
	}
}
