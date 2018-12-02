using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseOnFireManager : MonoBehaviour
{

    public static int houseCount;
    public static int houseSaved;
    public GameObject[] houseOnFire;
    

    // Use this for initialization
    void Start()
    {
        houseCount = houseOnFire.Length;
        houseSaved = 0;
    }

    // Method called when player saved a house
    public void AddHouseSaved()
    {
        houseSaved++;           
    }



}
