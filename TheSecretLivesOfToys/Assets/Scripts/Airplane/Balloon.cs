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
        ParticleSystem destructionTemp = Instantiate(destructionEffect, transform.position, transform.rotation);
        destructionTemp.transform.localScale = parent.localScale / 5;

        balloonManager.GetComponent<BalloonManager>().AddBalloonShot();
        
        Destroy(balloonString.gameObject);
        // Call box method to make it fall
        balloonBox.GetComponent<BalloonBox>().DropBox();
        Destroy(gameObject);
    }
}
