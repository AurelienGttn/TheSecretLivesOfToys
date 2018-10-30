using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public Vector3 TravelDirection;
    public int Speed;
    private AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.Play();

    }
    void Update()
    {
        transform.Translate(TravelDirection * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target") {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
