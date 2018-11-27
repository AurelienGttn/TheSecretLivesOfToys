using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using  ChobiAssets.KTP;

public class LoadScene : MonoBehaviour {
    private string nomScene;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Menu()
    {
        if (this.name == "Button_Play")
        {
            
            nomScene = "Jeu";
            Time.timeScale = 0f;

        }

        if (this.name == "Button_Missions")
        {
            nomScene = "ChooseMission";
        }

        if (this.name == "Button_Credits")
        {
            nomScene = "Credits";
        }

        if (this.name == "Button_Back")
        {
            nomScene = "Menu";
        }

        if (this.name == "Button_Sound")
        {
            nomScene = "SettingsSounds";
        }

        if (this.name == "Button_Manette")
        {
            nomScene = "Manette";
        }
        if (this.name == "Button_Clavier")
        {
            nomScene = "Clavier";
        }
        if (this.name == "Button_Quit")
        {
            Application.Quit();
        }


        if (this.name == "Button_TryAgain_Crash")
        {
            
            PanelMissions.missionPlaneBalloon = true;
            PanelMissions.missionPanel = true; 
            nomScene = "Jeu"; 
        }
        if (this.name == "Button_Menu")
        {
            nomScene = "Menu";
        }




        SceneManager.LoadScene(nomScene);
    }


    public void ChooseMission()
    {
       

        if (this.name == "Button_Plane_Rings")
        {
            nomScene = "PlaneLevel1";
        }

        if (this.name == "Button_Fire")
        {
            PanelMissions.missionTank = false;
            PanelMissions.missionFireTruck = true;

            nomScene = "Jeu";
        }

        if (this.name == "Button_Tank")
        {
            PanelMissions.missionTank = true;
            nomScene = "Jeu";
        }

        if (this.name == "Button_Plane_Balloon")
        {
            PanelMissions.missionPlaneBalloon = true;
            PanelMissions.missionTank = false;
            nomScene = "Jeu";
        }

        SceneManager.LoadScene(nomScene);
    }

    
}


         
