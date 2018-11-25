using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {

    public GameObject DestroyedGO;
    public GameObject explosionEffect;

    public float radius;
    public float force;

    private void OnDestroy()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Instantiate(DestroyedGO, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearObject in colliders)
        {
            Rigidbody rb = nearObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

        }
    }
}
