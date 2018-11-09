using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public Vector3 TravelDirection;
    [SerializeField] private int Speed;
    private Vector3 previousPos, nextPos;

    private RaycastHit hit;
    private Balloon balloonHit;

    private AudioSource m_AudioSource;

    private void Start()
    {
        // Play shoot sound when Bullet is created
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.Play();
    }

    void FixedUpdate()
    {
        // Update bullet position
        transform.Translate(TravelDirection * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            other.GetComponent<Balloon>().BalloonShot();
        }
        
        Destroy(gameObject);
    }
}
