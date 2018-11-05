using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    SpriteRenderer m_SpriteRenderer;
	// Use this for initialization
	void Start () {
        m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit, hit2;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.tag == "Target")
            {
                m_SpriteRenderer.color = new Color(255, 0, 0);
                Debug.Log("Target hit------------------------------");
            }
            else
            {
                m_SpriteRenderer.color = new Color(0, 0, 0);
                Debug.Log("No target");
            }
        }
	}
}
