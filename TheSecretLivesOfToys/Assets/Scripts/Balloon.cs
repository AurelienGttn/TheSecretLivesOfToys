using UnityEngine;

public class Balloon : MonoBehaviour {

    private BalloonManager balloonManager;
    [SerializeField] private ParticleSystem destructionEffect;

    private void Start()
    {
        balloonManager = FindObjectOfType<BalloonManager>();
    }

    //public void BalloonShot()
    //{
    //    Debug.Log("kaboom");
    //    // Instantiate on child balloon position, not on parent (balloon + string) position
    //    ParticleSystem destructionTemp = Instantiate(destructionEffect, transform.GetChild(0).position, transform.rotation);
    //    destructionTemp.transform.localScale = transform.localScale / 5;

    //    balloonManager.GetComponent<BalloonManager>().AddBalloonShot();

    //    Destroy(gameObject);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("Bullet"))
        {
            // Instantiate on child balloon position, not on parent (balloon + string) position
            ParticleSystem destructionTemp = Instantiate(destructionEffect, transform.GetChild(0).position, transform.rotation);
            destructionTemp.transform.localScale = transform.localScale/5;

            balloonManager.GetComponent<BalloonManager>().AddBalloonShot();
            
            Destroy(gameObject);
        }
    }
}
