using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ChobiAssets.KTP;

public class PanelMissions : MonoBehaviour
{
    private string nomScene;
    public static bool missionPanel = true;
    public static bool missionPanelCompleted = false;
    public static bool missionTank = true;
    public static bool missionFireTruck = false;
    public static bool missionPlaneRings = false;
    public static bool missionPlaneBalloon = false;

   
   
    public GameObject tank;
    public GameObject tank_clone; 
    public GameObject soldier;
    public GameObject IA;
    public GameObject panelMission;
    public GameObject panelMissionCompleted;
    private GameObject markerTank; 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!missionPanel)
        {
            Time.timeScale = 1f;
            panelMission.SetActive(false);
        }

        if (missionPanel)
        {
            Time.timeScale = 0f;
            panelMission.SetActive(true);
        }

        if (!missionPanelCompleted)
        {
            panelMissionCompleted.SetActive(false);
        }
        if (missionPanelCompleted)
        {
            Time.timeScale = 0f;
            panelMissionCompleted.SetActive(true);
        }

    }


    public void Mission()
    {
        if (this.name == "Button_AcceptMission" || this.name == "Button_TryAgain")
        {
            missionPanel = false;

            if (missionPlaneBalloon)
            {
                
                soldier.SetActive(true);
                soldier.transform.position = new Vector3(75, 1, 54); 
                IA.SetActive(true);
                tank.SetActive(false);
                tank_clone.SetActive(true); 
                markerTank = GameObject.Find("Marker");
                markerTank.SetActive(false); 

            }

            if (missionFireTruck)
            {
                soldier.SetActive(true);
                soldier.transform.position = new Vector3(-9, 24, 80);
                IA.SetActive(true);
            }
        }
        



        if (this.name == "Button_NextMission")
        {
            missionPanelCompleted = false;
            missionPanel = true;
            if (missionTank)
            {
                missionTank = false;
                missionPlaneBalloon = true;
                return; 
            }
            if (missionPlaneBalloon)
            {
                missionPlaneBalloon = false;
                missionFireTruck = true;
                return; 
            }
            if (missionFireTruck)
            {
                SceneManager.LoadScene("PlaneLevel1"); 
            }
           

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tank")
        {
            Time.timeScale = 0f;
            missionPanelCompleted = true; 

        }
    }
}
