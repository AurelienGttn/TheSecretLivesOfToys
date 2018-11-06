using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonManager: MonoBehaviour
{

    public static bool airplaneBalloonsLevel = false;
    // Name of the scene we want to show after victory
    private string victoryScene = "PlaneScene";

    public static int balloonCount;
    public static int balloonsShot;
    public GameObject[] balloons;

    // Use this for initialization
    void Start()
    {
        balloonCount = balloons.Length;
        balloonsShot = 0;
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
