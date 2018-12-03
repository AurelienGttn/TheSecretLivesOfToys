using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    static bool AudioBegin = false;

    void Awake()
    {
        if (!AudioBegin)
        {
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Jeu" || SceneManager.GetActiveScene().name == "PlaneRings")
        {
            GetComponent<AudioSource>().Stop();
            AudioBegin = false;
        }
    }
}