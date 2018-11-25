using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionDelay : MonoBehaviour {

    public float delay = 3f;

    float countdown;
    bool hasExploded = false;

    private void Start()
    {
        countdown = delay;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Destroy(gameObject);
        }
    }

}
