using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

    [SerializeField] private ParticleSystem destructionEffect;
    private GameObject m_Balloon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("Bullet"))
        {
            // Instantiate on child balloon position, not on parent position
            ParticleSystem destructionTemp = Instantiate(destructionEffect, transform.GetChild(0).position, transform.rotation);
            destructionTemp.transform.localScale = transform.localScale/5;
            Destroy(gameObject);
        }
    }
}
