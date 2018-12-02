using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {

    private RingManager ringManager;
    private bool nextRing;
    private ParticleSystem particles;

	void Start () {
        ringManager = FindObjectOfType<RingManager>();
        nextRing = false;
        particles = GetComponent<ParticleSystem>();
	}
	
	void Update () {
        // Add visual effects if this ring is the next target
        if (nextRing)
        {
            GetComponent<Renderer>().enabled = false;
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

                // Change visual effect so the player knows he did go through this ring
                ParticleSystem.ColorOverLifetimeModule colorModule = particles.colorOverLifetime;
                colorModule.color = Color.green;
            }
        }
    }

    public void setNextRing()
    {
        nextRing = true;
    }
}
