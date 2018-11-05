﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public Vector3 TravelDirection;
    [SerializeField] private int Speed;
    private AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.Play();
    }

    void FixedUpdate()
    {
        // TODO: Add Linecast to have more precise collision detection
        transform.Translate(TravelDirection * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target") {
            Destroy(other.gameObject);
        }

        // Don't collide with the shooter
        if (other.name != "Airplane")
        {
            Destroy(gameObject);
        }
    }
}
