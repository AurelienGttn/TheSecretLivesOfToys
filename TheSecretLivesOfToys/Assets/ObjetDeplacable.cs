using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ObjetDeplacable : MonoBehaviour
{
    public bool isCollide = false; 

  private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "floor")
        {
            isCollide = true; 
        }
    } 
    
    private void OnCollisionExit(Collision collision)
    {
         if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<PlayerController>().isDragging = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetButton("Fire1"))
            {
                collision.gameObject.GetComponent<PlayerController>().isDragging = true;
                Vector3 direction = TestDirection(collision.transform.gameObject);
                direction.x *= Input.GetAxisRaw("Vertical");
                direction.z *= Input.GetAxisRaw("Vertical");
                if (!isCollide)
                {
                    this.transform.Translate(direction * Time.deltaTime); 
                }                
            }
        }
    }

    Vector3 TestDirection(GameObject collision)
    {
        Vector3 positionPersonnage = new Vector3(collision.transform.position.x, 0f, collision.transform.position.z);
        Vector3 positionCube = new Vector3(this.transform.position.x, 0f, this.transform.position.z);
        Vector3 direction = (positionCube - positionPersonnage).normalized;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
        {
            direction.z = 0f;
            direction.x *= 1f;
        }
        else {
            direction.x = 0f;
            direction.z *= 1f;
        }

        return direction;
    }
    
}

