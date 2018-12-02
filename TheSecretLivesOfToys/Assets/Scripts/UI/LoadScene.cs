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
            PanelMissions.missionPanel = true; 
            
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
            nomScene = "PlaneRings";
            Time.timeScale = 0f;
            PanelPlaneRings.missionPanelRings = true;
            PanelMissions.missionTank = false;
            PanelMissions.missionPlaneBalloon = false;
            PanelMissions.missionFireTruck = false;
        }

        if (this.name == "Button_Fire")
        {
            PanelMissions.missionPanel = true;
            PanelMissions.missionTank = false;
            PanelMissions.missionPlaneBalloon = false; 
            PanelMissions.missionFireTruck = true;
            PanelPlaneRings.missionPanelRings = false; 

            nomScene = "Jeu";
        }

        if (this.name == "Button_Tank")
        {
            PanelMissions.missionPanel = true;
            PanelMissions.missionTank = true;
            PanelMissions.missionPlaneBalloon = false;
            PanelMissions.missionFireTruck = false;
            PanelPlaneRings.missionPanelRings = false;

            nomScene = "Jeu";
        }

        if (this.name == "Button_Plane_Balloon")
        {
            PanelMissions.missionPanel = true;
            PanelMissions.missionPlaneBalloon = true;
            PanelMissions.missionTank = false;
            PanelMissions.missionFireTruck = false;
            PanelPlaneRings.missionPanelRings = false;
            nomScene = "Jeu";
        }

        SceneManager.LoadScene(nomScene);
    }

    
}


         
