using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBox : MonoBehaviour {

    [SerializeField] private ParticleSystem explosion;

    public void DropBox()
    {
        // Make box fall
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.name.StartsWith("Bullet"))
        {
            // Explode on collision
            ParticleSystem destructionTemp = Instantiate(explosion, transform.position, transform.rotation);
            destructionTemp.transform.localScale = transform.parent.localScale / 5;
            Destroy(gameObject);
        }
    }
}
