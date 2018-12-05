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
        if (Input.GetKey(KeyCode.Escape)) // If the player press  escape 
        {
            Time.timeScale = 0f; // freeze time 
            panelPause.SetActive(true); // active panel pause 
        }
	}

   public void Resume() // if the player click on resume button 
   {
        Time.timeScale = 1.0f; // defreeze time 
        panelPause.SetActive(false);  // disable panel pause 
   }


   
      
    

}
