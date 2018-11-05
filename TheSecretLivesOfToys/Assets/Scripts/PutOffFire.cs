using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PutOffFire : MonoBehaviour {

    private float ParticulesLife = 100f;
    public List<GameObject> Particules;
    public static int HouseSaved = 0;
    public static int HouseOnFire = 2;
    public static bool FireTruckScene = false; 
    
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    public void onHit()
    {
        if (Particules.Count != 0)
        {
            if (ParticulesLife >= 0)
            {
                float NewScale = 1f * (ParticulesLife / 100f);
                for (int i = 0; i < Particules.Count; i++)
                {
                    Particules[i].transform.localScale = new Vector3(NewScale, NewScale, NewScale);
                }
                ParticulesLife = ParticulesLife - 0.45f;
            }
            else
            {       
                if (Particules[0] != null)  
                {
                    Particules[0].gameObject.SetActive(false);
                    Particules.Clear();
                    HouseSaved++;
                    Debug.Log("Maison sauvé : " + HouseSaved + "/" + HouseOnFire);
                }           
            }
        }
        if (HouseSaved == HouseOnFire)
        {
            SceneManager.LoadScene("MissionCompleted");
            FireTruckScene = true; 
        }

        
    }
}
