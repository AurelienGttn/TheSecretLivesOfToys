using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using  ChobiAssets.KTP;

public class LoadScene : MonoBehaviour {
    private string nomScene;
    
    public void Menu()
    {
        // if the player click on button play 
        if (this.name == "Button_Play")
        {
            // Initialize mission tank to true 
            PanelMissions.missionTank = true;
            // Launch the scene
            nomScene = "Jeu";
            // Initialize mission panel to true 
            PanelMissions.missionPanel = true; 
            
        }

        // if the player click on button missions 
        if (this.name == "Button_Missions")
        {
            nomScene = "ChooseMission"; // Launch the scene "Choose Mission"
        }

        // if the player click on button credits 
        if (this.name == "Button_Credits")
        {
            nomScene = "Credits"; // Launch the scene "Credits"
        }
        // if the player click on button back 
        if (this.name == "Button_Back")
        {
            nomScene = "Menu"; // Launch the scene "Menu"
        }
        // if the player click on button sound 
        if (this.name == "Button_Sound")
        {
            nomScene = "SettingsSounds"; // Launch the scene "SettingsSounds" 
        }
        // if the player click on button manette 
        if (this.name == "Button_Manette")
        {
            nomScene = "Manette"; //launch the scene "Manette" that displays the information to play with controller 
        }
        // if the player click on button clavier 
        if (this.name == "Button_Clavier")
        {
            nomScene = "Clavier"; // Launch the scene "Clavier" that displays the information to play with keyboard 
        }
        // if the player click on button quit 
        if (this.name == "Button_Quit")
        {
            Application.Quit(); // Quit the game 
        }

        // if the player click on button try again after a crash plane 
        if (this.name == "Button_TryAgain_Crash")
        {
            
            PanelMissions.missionPlaneBalloon = true; // Initialize the mission plane balloon
            PanelMissions.missionPanel = true; // Display the panel mission 
            nomScene = "Jeu"; // Launch the scene 
        }
        // if the player click on button menu 
        if (this.name == "Button_Menu")
        {
            // Initialize all the mission on false 
            PanelMissions.missionTank = false;
            PanelMissions.missionFireTruck = false;
            PanelMissions.missionPlaneBalloon = false;
            PanelPlaneRings.missionPanelRings = false;
            nomScene = "Menu"; // Launch the scene menu 
        }

        SceneManager.LoadScene(nomScene); // Launch the scene according to its name
    }

    // Fonction to choose your mission 
    public void ChooseMission()
    {
       // if the mission is plane rings 
        if (this.name == "Button_Plane_Rings")
        {
            nomScene = "PlaneRings"; // Lauch the scene Plane Rings 
            Time.timeScale = 0f; // Freeze the time 
            PanelPlaneRings.missionPanelRings = true; // Initialize mission planeRings to true 
            PanelMissions.missionTank = false; // Initialize mission tank to false 
            PanelMissions.missionPlaneBalloon = false; // Initialize mission planeBallons to false 
            PanelMissions.missionFireTruck = false; // Initialize mission firetruck to false 
        }
        
        // same method for the mission firetruck
        if (this.name == "Button_Fire")
        {
            PanelMissions.missionPanel = true;
            PanelMissions.missionTank = false;
            PanelMissions.missionPlaneBalloon = false; 
            PanelMissions.missionFireTruck = true;
            PanelPlaneRings.missionPanelRings = false; 

            nomScene = "Jeu";
        }

        // same method for the mission tank 
        if (this.name == "Button_Tank")
        {
            PanelMissions.missionPanel = true;
            PanelMissions.missionTank = true;
            PanelMissions.missionPlaneBalloon = false;
            PanelMissions.missionFireTruck = false;
            PanelPlaneRings.missionPanelRings = false;

            nomScene = "Jeu";
        }
        // same method for the mission plane balloon
        if (this.name == "Button_Plane_Balloon")
        {
            PanelMissions.missionPanel = true;
            PanelMissions.missionPlaneBalloon = true;
            PanelMissions.missionTank = false;
            PanelMissions.missionFireTruck = false;
            PanelPlaneRings.missionPanelRings = false;
            nomScene = "Jeu";
        }

        SceneManager.LoadScene(nomScene); // Launch the scene according to its name

    }


}


         
