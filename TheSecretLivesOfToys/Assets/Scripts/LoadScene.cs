using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using  ChobiAssets.KTP;

public class LoadScene : MonoBehaviour {
    private string nomScene;
    public static bool firstMission = false;
    public static bool missionTank = false;
    public static bool missionPlane = false; 
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangerScene()
    {
        if (this.name == "Button_Play") 
        {
            firstMission = true; 
            nomScene = "Mission";
        }

        if (this.name == "Button_Missions")
        {
            nomScene = "ChooseMission";
        }

        if (this.name == "Button_Credits")
        {
            nomScene = "Credits";
        }

        if(this.name == "Button_WindowClose")
        {
            nomScene = "Menu";
        }

        if(this.name == "Button_Sound")
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

        if(this.name == "Button_AcceptMission")
        {
            if(firstMission)
                nomScene = "FireTruck";
            if (missionTank)
                nomScene = "TankScene";
            if (missionPlane)
                nomScene = "PlaneLevel1"; 
        }
        
        if (this.name == "Button_NextMission")
        {
            if (PutOffFire.FireTruckScene)
            {
                firstMission = false;
                missionTank = true; 
                nomScene = "Mission"; 
            }
            if (Damage_Control_CS.TankScene)
            {
                firstMission = false; 
                missionTank = false;
                missionPlane = true; 
                nomScene = "Mission";
            }

            if (RingManager.airplaneRingsLevel)
            {
                firstMission = false;
                missionTank = false;
                missionPlane = false;
                nomScene = "ContenuNonDispo";
            }
        }

        if(this.name == "Button_Menu")
        {
            nomScene = "Menu"; 
        }

        if (this.name == "Button_Plane")
        {
            nomScene = "PlaneLevel1";
        }

        if (this.name == "Button_Fire")
        {
            nomScene = "FireTruck";
        }

        if (this.name == "Button_Tank")
        {
            nomScene = "TankScene"; 
        }
       
        SceneManager.LoadScene(nomScene);
    }
}
