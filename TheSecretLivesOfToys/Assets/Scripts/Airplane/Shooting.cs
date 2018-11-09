using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Shooting : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject BulletEmitter;
    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire2") && canShoot)
        {
            StartCoroutine("Shoot");
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        // Create bullet
        GameObject BulletClone = Instantiate(Bullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation);

        Bullet.GetComponent<BulletScript>().TravelDirection = Bullet.transform.forward;

        // Destroy bullet after 3 seconds
        Destroy(BulletClone, 3.0f);

        // Wait before next shoot
        yield return new WaitForSeconds(0.1f);
        canShoot = true;
    }
}