using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonManager: MonoBehaviour
{

    public static bool airplaneBalloonsLevel = false;
    // Name of the scene we want to show after victory
    private string victoryScene = "MissionCompleted";

    public static int balloonCount;
    public static int balloonsShot;
    public GameObject[] balloons;

    // Use this for initialization
    void Start()
    {
        balloonCount = balloons.Length;
        balloonsShot = 0;
    }

    // A enlever, test menu
    private void Update()
    {
        
        if (Input.GetButton("E"))
        {
            airplaneBalloonsLevel = true;
            SceneManager.LoadScene(victoryScene);
        }
    }

    // Method called when player shoots a balloon
    public void AddBalloonShot()
    {
        balloonsShot++;
        if (balloonsShot == balloonCount)
            Victory();
    }

    void Victory()
    {
        airplaneBalloonsLevel = true;
        SceneManager.LoadScene(victoryScene);
    }
}
