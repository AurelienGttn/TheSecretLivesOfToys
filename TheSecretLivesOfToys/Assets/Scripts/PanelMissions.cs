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
    public static bool missionPlaneBalloon = false;

    public GameObject IA;
    public GameObject panelMission;
    public GameObject panelMissionCompleted;
    private GameObject markerTank;
    public GameObject plane;
    public GameObject Ring;
    public GameObject[] FX_Emplacement;
    private GameObject targets;
    public GameObject panelGameOver;
    public GameObject cmvcam_plane;

    public GameObject tank;
    public GameObject tank_clone; 
    public GameObject soldier;
    public GameObject obstacle_tank;

    public GameObject keyPrefab;
    public GameObject bridgePrefab;

    public TimelineManager timelineManager;
    public Camera cutsceneCamera;
    public Canvas blackScreen;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!missionPanel)
        {
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
        /*if (missionTank)
        {
            if(this.name == "Button_TryAgain")
            {
                SceneManager.LoadScene("Jeu");
            }
        }*/

        if (name == "Button_AcceptMission" || name == "Button_TryAgain")
        {
            missionPanel = false;
            panelGameOver.SetActive(false);

            if (missionPlaneBalloon)
            {
                soldier.SetActive(true);
                Key_Plane.haveKey = false;
                if (FindObjectOfType<Key_Plane>() == null)
                {
                    GameObject bridge = Instantiate(bridgePrefab, new Vector3(-62.43f, 20.92f, 133.58f), Quaternion.Euler(new Vector3(0, 90, 0)));
                    GameObject key = Instantiate(keyPrefab, new Vector3(-80, 22.5f, 133), Quaternion.identity);
                    key.GetComponentInChildren<Key_Plane>().pont = bridge;
                }
                GameObject[] tankObstacles = GameObject.FindGameObjectsWithTag("DestroyObstacle");
                for (int i = 0; i < tankObstacles.Length; i++)
                {
                    tankObstacles[i].SetActive(false);
                }
                soldier.GetComponent<PlayerController>().enabled = false;
                soldier.transform.position = new Vector3(75, 0, 54);
                soldier.transform.rotation = Quaternion.identity;
                IA.SetActive(true);
                tank.SetActive(false);
                tank_clone.SetActive(true);
                markerTank = GameObject.Find("Marker");
                if (markerTank != null)
                    markerTank.SetActive(false);
                FX_Emplacement[1].SetActive(true);
                // play cutscene
                blackScreen.enabled = true;
                cutsceneCamera.enabled = true;
                timelineManager.timelineAirplane.SetActive(true);
                timelineManager.cutsceneAirplane.Play();
            }

            else if (missionFireTruck)
            {
                soldier.SetActive(true);
                soldier.GetComponent<PlayerController>().enabled = false;
                cmvcam_plane.SetActive(false);
                soldier.transform.position = new Vector3(-9, 24, 80);
                IA.SetActive(true);
                FX_Emplacement[2].SetActive(true);
                targets = GameObject.Find("Targets");
                Balloon[] balloons = targets.GetComponentsInChildren<Balloon>();
                for (int i = 0; i < balloons.Length; i++)
                {
                    balloons[i].BalloonShot();
                }
                Ring.SetActive(false);
                obstacle_tank.SetActive(false);
                tank.SetActive(false);
                tank_clone.SetActive(true);
                // play cutscene
                blackScreen.enabled = true;
                cutsceneCamera.enabled = true;
                timelineManager.timelineFiretruck.SetActive(true);
                timelineManager.cutsceneFiretruck.Play();
            }

            else if (missionTank)
            {
                // play cutscene
                soldier.GetComponent<PlayerController>().enabled = false;
                soldier.transform.position = new Vector3(-133, 0, -88);
                soldier.transform.rotation = Quaternion.identity;
                blackScreen.enabled = true;
                cutsceneCamera.enabled = true;
                timelineManager.timelineTank.SetActive(true);
                timelineManager.cutsceneTank.Play();
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
                missionTank = false;
                missionPlaneBalloon = false;
                missionFireTruck = false;
                missionPanel = false;
                PanelPlaneRings.missionPanelRings = true;
                StartCoroutine(WaitChangementScene());
                SceneManager.LoadScene("PlaneRings"); 
            }
           

        }
    }

    private IEnumerator WaitChangementScene()
    {
        yield return new WaitForSeconds(2f);

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
