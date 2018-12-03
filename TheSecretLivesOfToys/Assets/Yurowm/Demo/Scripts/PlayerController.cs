using UnityEngine;
using System.Collections;
using ChobiAssets.KTP;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    public int Speed = 5;
    private Vector3 DirectionDeplacement = Vector3.zero;
    private CharacterController Player;

    public int Jump = 5;
    public int gravite = 20;
    public int RunSpeed = 10;

    bool isRunning, isWalking, isIdle;

    private Animator animator;

    void Awake()
    {

        animator = GetComponent<Animator>();

        for (int i = 0; i <= 11; i++)
        {
            Physics.IgnoreLayerCollision(9, i, false); // Reset settings.
            Physics.IgnoreLayerCollision(11, i, false); // Reset settings.
        }


    }

    public void Stay()
    {
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 0f);

    }

    public void Walk()
    {
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 0.5f);
    }

    public void Run()
    {
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 1f);
    }

    public void Attack()
    {
        Aiming();
        animator.SetTrigger("Attack");
    }

    public void Death()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            animator.Play("Idle", 0);
        else
            animator.SetTrigger("Death");
    }

    public void JumpAnim()
    {
        animator.SetBool("Squat", false);
        animator.SetFloat("Speed", 0f);
        animator.SetBool("Aiming", false);
        animator.SetTrigger("Jump");
    }

    public void Aiming()
    {
        animator.SetBool("Squat", false);
        animator.SetFloat("Speed", 0f);
        animator.SetBool("Aiming", true);
    }

    public void Sitting()
    {
        animator.SetBool("Squat", !animator.GetBool("Squat"));
        animator.SetBool("Aiming", false);
    }


    // -------------------------- Deplacement ----------------- //
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;
    public bool isgrounded = true;
    public bool isJumping = false;
    public bool isDragging = false;

    public Vector3 jumSpeed;

    private Rigidbody m_rigidbody;
    public float velocity;
    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

    }


    private void Update()
    {
        velocity = m_rigidbody.velocity.y;
        // if character is falling, do as if it was jumping
        if (Mathf.Abs(m_rigidbody.velocity.y) > 0.1)
        {
            isJumping = true;
            isgrounded = false;
        }
        else
        {
            isJumping = false;
            isgrounded = true;
        }

        for (int i = 0; i <= 11; i++)
        {
            Physics.IgnoreLayerCollision(9, i, false); // Reset settings.
            Physics.IgnoreLayerCollision(11, i, false); // Reset settings.
        }
        Physics.IgnoreLayerCollision(9, 9, false); // Wheels do not collide with each other.
        Physics.IgnoreLayerCollision(9, 11, false); // Wheels do not collide with MainBody.
        for (int i = 0; i <= 11; i++)
        {
            Physics.IgnoreLayerCollision(10, i, false); // Suspensions do not collide with anything.
        }

        if (!isDragging)
        {
            transform.Rotate(0, Input.GetAxisRaw("Horizontal") * 100.0f * Time.deltaTime, 0);
        }

       /* if (isgrounded == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Jump")))
        {
            isWalking = false;
            isRunning = false;
            animator.SetFloat("Speed", 0);
            animator.SetTrigger("Jump");
            // Préparation du saut 
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumSpeed.y;
            // Saut
            gameObject.GetComponent<Rigidbody>().velocity = v;
            isgrounded = false;
        } */

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (isgrounded)
            {
                // Run 
                if (Input.GetButton("Run"))
                {
                    isRunning = true;
                    isWalking = false;
                    transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * runSpeed * Time.deltaTime);
                    ChooseAnimation();
                }
                // Walk 
                else
                {
                    transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * walkSpeed * Time.deltaTime);
                    isWalking = true;
                    isRunning = false;
                    ChooseAnimation();
                }
            }
            else if (isJumping)
            {
                isWalking = false;
                isRunning = false;
                transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * 6 * Time.deltaTime);
                ChooseAnimation();
            }
        }
        else
        {
            isWalking = false;
            isRunning = false;
            ChooseAnimation();
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            isgrounded = true;
        }
    }


    void ChooseAnimation()
    {
        if (isRunning)
        {
            Run();
        }
        else if (isWalking)
        {
            Walk();
        }
        else
        {
            Stay();
        }
    }

    // Controler Véhicule
    public GameObject[] vehicule;
    public GameObject cmvcam_firetruck;
    public GameObject cameraTank;
    public GameObject[] FX_Emplacement;
    public GameObject crossHairPlane;
    public GameObject IA;
    public GameObject key_Plane;
    public GameObject audioEngine_Tank;
    public GameObject cmvcam_plane;
    public GameObject cameraTruck;
    public GameObject multipurposeMainCamera; 

    void OnCollisionStay(Collision collision)
    {

        
        // Tank 
        if (collision.gameObject.tag == "Tank" && Input.GetButton("F"))
        {
            gameObject.SetActive(false);
            FX_Emplacement[0].SetActive(false);
            vehicule[0].GetComponent<ID_Control_CS>().enabled = true;
            vehicule[0].GetComponent<Damage_Control_CS>().enabled = true;
            vehicule[0].GetComponent<AudioSource>().Play();

            cameraTank.SetActive(true);
            this.transform.GetChild(0);
            IA.SetActive(false);
            for (int i = 0; i <= 11; i++)
            {
                Physics.IgnoreLayerCollision(9, i, false); // Reset settings.
                Physics.IgnoreLayerCollision(11, i, false); // Reset settings.
            }
            Physics.IgnoreLayerCollision(9, 9, true); // Wheels do not collide with each other.
            Physics.IgnoreLayerCollision(9, 11, true); // Wheels do not collide with MainBody.
            for (int i = 0; i <= 11; i++)
            {
                Physics.IgnoreLayerCollision(10, i, true); // Suspensions do not collide with anything.
            }
            audioEngine_Tank.GetComponent<AudioSource>().enabled = true;


        }
        //Plane
        if (collision.gameObject.tag == "Player" && Key_Plane.haveKey && Input.GetButton("F"))
        {
            multipurposeMainCamera.SetActive(true); 
            gameObject.SetActive(false);
            vehicule[1].GetComponent<AirplaneController>().enabled = true;
            vehicule[1].GetComponent<AirplaneAudio>().enabled = true;
            vehicule[1].GetComponent<Animator>().enabled = true;
            vehicule[1].GetComponent<AudioSource>().enabled = true;
            this.transform.GetChild(0);
            cmvcam_plane.SetActive(true);
            cameraTruck.SetActive(false); 
            FX_Emplacement[1].SetActive(false);

            if (PanelMissions.missionPlaneBalloon)
            {
                vehicule[1].GetComponent<Shooting>().enabled = true;
                crossHairPlane.SetActive(true);
                IA.SetActive(false);
                key_Plane.SetActive(false);
            }
            
        }

        // FireTruck
        if (collision.gameObject.tag == "FireTruck" && Input.GetButton("F"))
        {
            gameObject.SetActive(false);
            FX_Emplacement[2].SetActive(false);
            vehicule[2].GetComponent<VehiculeController>().enabled = true;
            vehicule[2].GetComponent<AudioSource>().enabled = true;
            cameraTruck.SetActive(true);
            cmvcam_firetruck.SetActive(true);
            this.transform.GetChild(0);
            IA.SetActive(false);

        }

        if (collision.gameObject.tag == "Player" && !Key_Plane.haveKey && (Input.GetButton("Fire2") || Input.GetButton("F")))
        {
          
            key_Plane.SetActive(true);
        }


    }
}
