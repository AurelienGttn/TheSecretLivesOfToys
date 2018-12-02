using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public GameObject panelPause;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            panelPause.SetActive(true); 
        }
	}

   public void Resume()
   {
        Time.timeScale = 1.0f;
        panelPause.SetActive(false); 
   }


   
      
    

}
