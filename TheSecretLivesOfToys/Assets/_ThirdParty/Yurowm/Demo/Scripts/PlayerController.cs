using UnityEngine;
using ChobiAssets.KTP;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private bool isRunning, isWalking, isIdle;      // booleans to change values in the animator
    private Animator animator;                      // animator that controls the animations

    [Header("Movement variables")]
    public float walkSpeed = 10f;                    // how fast the character walks
    public float runSpeed = 20f;                    // how fast the character runs
    public float turnSpeed = 150f;                  // how fast the character rotates

    private float yAxisVelocity;                    // used to know if the character is in the air
    [HideInInspector]
    public bool isJumping = false;                  // used to prevent animation (walking/running) while in the air
    

    void Awake()
    {

        animator = GetComponent<Animator>();

        for (int i = 0; i <= 11; i++)
        {
            Physics.IgnoreLayerCollision(9, i, false); // Reset settings.
            Physics.IgnoreLayerCollision(11, i, false); // Reset settings.
        }


    }

    private void Update()
    {
        #region Reset tank physics
        // The tank changes colliders settings so we need
        // to reset them when we get back to the soldier

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
        
        #endregion


        #region Movement and animation

        yAxisVelocity = GetComponent<Rigidbody>().velocity.y;
        // if character is falling, do as if it was jumping
        // to prevent walking/running in the air
        isJumping = Mathf.Abs(yAxisVelocity) > 0.1;

        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * turnSpeed * Time.deltaTime, 0);

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (!isJumping)
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

    #region Animator control
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

    public void JumpAnim()
    {
        animator.SetBool("Squat", false);
        animator.SetFloat("Speed", 0f);
        animator.SetBool("Aiming", false);
        animator.SetTrigger("Jump");
    }
    #endregion

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
    #endregion

    #region Control vehicle

    // There are many things to enable/disable when entering/exiting
    // a vehicle such as cameras. This is where this is handled.
    [Header("Vehicle change variables")]
    public GameObject IA;
    public GameObject[] vehicule;
    public GameObject[] FX_Emplacement;
    public GameObject cameraTank;
    public GameObject cameraTruck;
    public GameObject cmvcam_firetruck;
    public GameObject multipurposeCamera;
    public GameObject cmvcam_plane;
    public GameObject crosshairPlane;
    public GameObject missingKey;

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


        }

        //Plane
        if (collision.gameObject.tag == "Player" && Input.GetButton("F"))
        {
            if (Key_Plane.haveKey)
            {
                multipurposeCamera.SetActive(true);
                gameObject.SetActive(false);
                vehicule[1].GetComponent<AirplaneController>().enabled = true;
                vehicule[1].GetComponent<AirplaneAudio>().enabled = true;
                vehicule[1].GetComponent<Animator>().enabled = true;
                vehicule[1].GetComponent<AudioSource>().enabled = true;
                cmvcam_plane.SetActive(true);
                cameraTruck.SetActive(false);
                FX_Emplacement[1].SetActive(false);

                if (PanelMissions.missionPlaneBalloon)
                {
                    vehicule[1].GetComponent<Shooting>().enabled = true;
                    crosshairPlane.SetActive(true);
                    IA.SetActive(false);
                    missingKey.SetActive(false);
                }
            }
            else
            {
                missingKey.SetActive(true);
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
            IA.SetActive(false);

        }
    }
    #endregion
}