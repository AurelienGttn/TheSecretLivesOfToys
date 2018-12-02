using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFire : MonoBehaviour {

    private ParticleSystem[] fireParticles;
    private Light fireLight;

    void Start () {
        fireParticles = GetComponentsInChildren<ParticleSystem>();
        fireLight = GetComponentInChildren<Light>();
        foreach(ParticleSystem pS in fireParticles)
            pS.Stop();
        fireLight.enabled = false;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "BalloonBox")
        {
            foreach (ParticleSystem pS in fireParticles)
                pS.Play();
            fireLight.enabled = true;
        }
    }


}
