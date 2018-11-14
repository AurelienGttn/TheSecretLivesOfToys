using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public Vector3 TravelDirection;
    [SerializeField] private int Speed;
    private Vector3 previousPos, nextPos;
    private RaycastHit hit;

    private Balloon balloonHit;
    private RaycastHit2D[] hits;
    private AudioSource m_AudioSource;

    private void Start()
    {
        previousPos = transform.position;
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.Play();
    }

    void FixedUpdate()
    {
        // TODO: Add Linecast to have more precise collision detection
        previousPos = transform.position;
        transform.Translate(TravelDirection * Speed * Time.deltaTime);

        hits = Physics2D.LinecastAll(previousPos, transform.position);
        //if (hits != null)
        //    BulletCollision(hits);
    }

    //private void BulletCollision(RaycastHit2D[] hits)
    //{
    //    for (int i = 0; i < hits.Length; i++)
    //    {
    //        Collider2D other = hits[i].collider;
    //        Debug.Log("Hit " + other.name);
    //        if (other.tag == "Target")
    //        {
    //            Debug.Log("pew pew");
    //            if (other.isTrigger)
    //                other.GetComponent<Balloon>().BalloonShot();
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            Destroy(other.gameObject);
        }

        // Don't collide with the shooter
        if (other.name != "Airplane")
        {
            Destroy(gameObject);
        }
    }
}
