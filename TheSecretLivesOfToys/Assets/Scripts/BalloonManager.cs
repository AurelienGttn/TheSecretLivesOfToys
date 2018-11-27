using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonManager: MonoBehaviour
{

    public static int balloonCount;
    public static int balloonsShot;
    public GameObject[] balloons;

    public GameObject landingRing;

    // Use this for initialization
    void Start()
    {
        balloonCount = balloons.Length;
        balloonsShot = 0;
    }

    public void Update()
    {
        
    }

    // Method called when player shoots a balloon
    public void AddBalloonShot()
    {
       
        balloonsShot++;
        if (balloonsShot == balloonCount)
        {
            Land();
        }
            
    }

    void Land()
    {
        landingRing.SetActive(true); 


    }
}
