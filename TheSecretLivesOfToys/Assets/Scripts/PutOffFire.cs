using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PutOffFire : MonoBehaviour {

    private float ParticulesLife = 100f;
    public List<GameObject> Particules;
    private HouseOnFireManager houseOnFireManager;
    //public static int HouseSaved = 0;
    //public static int HouseOnFire = 7;
    public static bool FireTruckScene = false; 
    
    // Use this for initialization
    void Start () {

        houseOnFireManager = FindObjectOfType<HouseOnFireManager>();

    }
	
	// Update is called once per frame
	void Update () {
       
    }

    public void onHit()
    {
        if (Particules.Count != 0)
        {
            if (ParticulesLife >= 95)
            {
                float scaleMultiplier = 1f * (ParticulesLife / 100f);
                for (int i = 0; i < Particules.Count; i++)
                {
                    Vector3 currentScale = Particules[i].transform.localScale;
                    currentScale = new Vector3(scaleMultiplier * currentScale.x, scaleMultiplier * currentScale.y, scaleMultiplier * currentScale.z);
                    Particules[i].transform.localScale = currentScale;
                    if (Particules[i].GetComponent<Light>() != null)
                    {
                        Particules[i].GetComponent<Light>().range -= 0.04f;
                    }
                }
                ParticulesLife = ParticulesLife - 0.05f;
            }
            else
            {       
                if (Particules[0] != null)  
                {
                    Particules[0].gameObject.SetActive(false);
                    Particules.Clear();

                    houseOnFireManager.GetComponent<HouseOnFireManager>().AddHouseSaved(); 
                }           
            }
        }      
    }
}
