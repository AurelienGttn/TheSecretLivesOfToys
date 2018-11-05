using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour {
    
    [SerializeField] private Transform m_BulletEmitter;
    [SerializeField] private Camera m_Camera;
    [SerializeField] private RectTransform m_Crosshair;
    private Image m_CrosshairImage;

	// Use this for initialization
	void Start () {
        m_CrosshairImage = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        // Place the crosshair on the first object it collides with
        if (Physics.Raycast(m_BulletEmitter.transform.position, -m_BulletEmitter.transform.up, out hit))
        {
            if (hit.collider && !hit.collider.name.StartsWith("Bullet"))
            {
                m_Crosshair.transform.position = m_Camera.WorldToScreenPoint(hit.point);
                // Change color of crosshair if it is on a target
                if (hit.collider.tag == "Target")
                {
                    m_CrosshairImage.color = Color.red;
                }
                else
                {
                    m_CrosshairImage.color = Color.black;
                }
            }
        }
	}
}
