using UnityEngine;

public class Balloon : MonoBehaviour {

    private BalloonManager balloonManager;
    [SerializeField] private ParticleSystem destructionEffect;

    private Transform parent;
    private Transform balloonString;
    private Transform balloonBox;

    private void Start()
    {
        balloonManager = FindObjectOfType<BalloonManager>();
        parent = transform.parent;
        balloonString = parent.GetChild(1);
        balloonBox = parent.GetChild(2);
    }

    public void BalloonShot()
    {
        if (GetComponent<Renderer>().enabled == true)
        {
            ParticleSystem destructionTemp = Instantiate(destructionEffect, transform.position, transform.rotation);
            destructionTemp.transform.localScale = parent.localScale / 5;
            GetComponent<AudioSource>().Play();

            balloonManager.GetComponent<BalloonManager>().AddBalloonShot();
            GetComponent<Renderer>().enabled = false;
            Collider[] coll = GetComponents<Collider>();
            for (int i = 0; i < coll.Length; i++)
            {
                coll[i].enabled = false;
            }
            Destroy(balloonString.gameObject);
            // Call box method to make it fall
            balloonBox.GetComponent<BalloonBox>().DropBox();
            Destroy(gameObject, GetComponent<AudioSource>().clip.length);
        }
    }
}
