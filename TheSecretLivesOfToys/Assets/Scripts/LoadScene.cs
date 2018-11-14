using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using  ChobiAssets.KTP;

public class LoadScene : MonoBehaviour {
    private string nomScene;
    public static bool missionFireTruck = false;
    public static bool missionTank = false;
    public static bool missionPlaneRings = false;
    public static bool missionPlaneBalloon = false;


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
            missionTank = true; 
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

        if(this.name == "Button_AcceptMission" || this.name == "Button_TryAgain")
        {
            if(missionTank)
                nomScene = "TankScene";

            if (missionPlaneBalloon)
                nomScene = "PlaneLevel2";

            if (missionFireTruck)
                nomScene = "FireTruck";
             
            if(missionPlaneRings)
                nomScene = "PlaneLevel1";
        }
        
        if (this.name == "Button_NextMission")
        {
            if (Damage_Control_CS.TankScene)
            {
                missionTank = false; 
                missionPlaneBalloon = true;
                missionFireTruck = false;
                missionPlaneRings = false;
                nomScene = "Mission";
            }

            if (BalloonManager.airplaneBalloonsLevel)
            {
                missionTank = false;
                missionPlaneBalloon = false;
                missionFireTruck = true;
                missionPlaneRings = false;
                nomScene = "Mission";
            }

            if (PutOffFire.FireTruckScene)
            {
                missionTank = false;
                missionPlaneBalloon = false;
                missionFireTruck = false;
                missionPlaneRings = true;
                nomScene = "Mission";
            }

            if (RingManager.airplaneRingsLevel)
            {
                missionTank = false;
                missionPlaneBalloon = false;
                missionFireTruck = false;
                missionPlaneRings = false;
                nomScene = "ContenuNonDispo";
            }
        }

        if(this.name == "Button_Menu")
        {
            nomScene = "Menu"; 
        }

        if (this.name == "Button_Plane_Rings")
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

        if (this.name == "Button_Plane_Balloon")
        {
            nomScene = "PlaneLevel2";
        }


        SceneManager.LoadScene(nomScene);
    }
}
