using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {

    public GameObject DestroyedGO;
    

    public float radius;
    public float force;

    public void SpawnDestroy()
    {
        Instantiate(DestroyedGO, transform.position, transform.rotation);
    }

    private void OnDestroy()
    {

       
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
