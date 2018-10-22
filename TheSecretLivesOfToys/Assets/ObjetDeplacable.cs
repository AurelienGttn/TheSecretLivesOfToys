using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ObjetDeplacable : MonoBehaviour
{
    private Rigidbody rb;

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetButton("Fire1"))
        {
            collision.gameObject.GetComponent<ThirdPersonCharacter>().m_PushPull = true;
            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            direction = direction.normalized;
            transform.position += direction * (2.0f * Time.deltaTime);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ThirdPersonCharacter>().m_PushPull = false;
        }
    }
}

