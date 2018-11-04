using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {

    private RingManager ringManager;
    private bool nextRing;
    [SerializeField] private ParticleSystem particles;

	void Start () {
        ringManager = FindObjectOfType<RingManager>();
        nextRing = false;
        particles = GetComponent<ParticleSystem>();
	}
	
	void Update () {
        // Add visual effects if this ring is the next target
        if (nextRing)
        {
            Debug.Log("Particles activated");
            GetComponent<Renderer>().enabled = false;
            //Destroy(this);
            particles.Play();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (nextRing)
        {
            if (other.tag == "Player")
            {
                nextRing = false;
                ringManager.AddRingDone();

                ParticleSystem.MainModule mainModule = particles.main;
                ParticleSystem.ColorOverLifetimeModule colorModule = particles.colorOverLifetime;
                colorModule.color = Color.green;
                //mainModule.startColor = Color.green;
            }
        }
    }

    public void setNextRing()
    {
        nextRing = true;
    }
}
