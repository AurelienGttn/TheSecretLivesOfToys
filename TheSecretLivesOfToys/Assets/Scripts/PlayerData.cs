using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    int missionChoice = 1;
	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	public void SetMission (int i) {
        missionChoice = i;
    }

    public int GetMission()
    {
        return missionChoice; 
    }
}
