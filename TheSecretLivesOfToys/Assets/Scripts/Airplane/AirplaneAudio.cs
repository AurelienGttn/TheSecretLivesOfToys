using UnityEngine;

public class AirplaneAudio : MonoBehaviour {

    private AirplaneController m_Plane;
    private AudioSource m_PropellerSoundSource;

	void Awake () {
        m_Plane = GetComponent<AirplaneController>();
        m_PropellerSoundSource = GetComponent<AudioSource>();
        
        Update();

        m_PropellerSoundSource.Play();
    }
	
	void Update () {
        // Update volume according to speed
        if (GroundTrigger.triggered)
            m_PropellerSoundSource.volume = Mathf.InverseLerp(0, m_Plane.neutralSpeed, m_Plane.speed);
        else
            m_PropellerSoundSource.volume = Mathf.InverseLerp(0, m_Plane.minimumSpeed, m_Plane.speed);
    }
}
