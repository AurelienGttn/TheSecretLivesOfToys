using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseOnFireManager : MonoBehaviour
{
    // number of houses on fire
    public static int houseCount;
    // number of houses saved   
    public static int houseSaved;
    // GameObject with all the houses on fire 
    public GameObject[] houseOnFire;
    

    // Initialization of the variables 
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
