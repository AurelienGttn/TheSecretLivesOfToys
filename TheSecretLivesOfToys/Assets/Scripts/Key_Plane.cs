using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Plane : MonoBehaviour {

    public static bool haveKey = true;
    public GameObject pont;
    [SerializeField] private ParticleSystem explostionPont;

    // Use this for initialization
    void Start() {
        
    }   
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 100 * Time.deltaTime, 0)); 
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            haveKey = true;
            Destroy(this.gameObject);
            pont.SetActive(false);
            ParticleSystem crashExplosionClone = Instantiate(explostionPont, pont.transform.position, Quaternion.identity);
            crashExplosionClone.transform.localScale = pont.transform.localScale;
        }
    }
}
