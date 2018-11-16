using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class PlayerController : MonoBehaviour {

	public Transform rightGunBone;
	public Transform leftGunBone;
	public Arsenal[] arsenal;
    public int Speed = 5;
    private Vector3 DirectionDeplacement = Vector3.zero;
    private CharacterController Player;

    public int Jump = 5;
    public int gravite = 20;
    public int RunSpeed = 10;

    bool isRunning, isWalking, isIdle;

    private Animator animator;

	void Awake() {

		animator = GetComponent<Animator> ();
		if (arsenal.Length > 0)
			SetArsenal (arsenal[0].name);

        for (int i = 0; i <= 11; i++)
        {
            Physics.IgnoreLayerCollision(9, i, true); // Reset settings.
            Physics.IgnoreLayerCollision(11, i, true); // Reset settings.
        }
        Physics.IgnoreLayerCollision(9, 9, false); // Wheels do not collide with each other.
        Physics.IgnoreLayerCollision(9, 11, false); // Wheels do not collide with MainBody.
        for (int i = 0; i <= 11; i++)
        {
            Physics.IgnoreLayerCollision(10, i, false); // Suspensions do not collide with anything.
        }

    }

	public void SetArsenal(string name) {
		foreach (Arsenal hand in arsenal) {
			if (hand.name == name) {
				if (rightGunBone.childCount > 0)
					Destroy(rightGunBone.GetChild(0).gameObject);
				if (leftGunBone.childCount > 0)
					Destroy(leftGunBone.GetChild(0).gameObject);
				if (hand.rightGun != null) {
					GameObject newRightGun = (GameObject) Instantiate(hand.rightGun);
					newRightGun.transform.parent = rightGunBone;
					newRightGun.transform.localPosition = Vector3.zero;
					newRightGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
					}
				if (hand.leftGun != null) {
					GameObject newLeftGun = (GameObject) Instantiate(hand.leftGun);
					newLeftGun.transform.parent = leftGunBone;
					newLeftGun.transform.localPosition = Vector3.zero;
					newLeftGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
				}
				animator.runtimeAnimatorController = hand.controller;
				return;
				}
		}
	}

	[System.Serializable]
	public struct Arsenal {
		public string name;
		public GameObject rightGun;
		public GameObject leftGun;
		public RuntimeAnimatorController controller;
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

   /* public void Damage()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death")) return;
        int id = Random.Range(0, countOfDamageAnimations);
        if (countOfDamageAnimations > 1)
            while (id == lastDamageAnimation)
                id = Random.Range(0, countOfDamageAnimations);
        lastDamageAnimation = id;
        animator.SetInteger("DamageID", id);
        animator.SetTrigger("Damage");
    } */

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
    public bool isDragging = false;

    public Vector3 jumSpeed;

    private void Start()
    {
    }

   
    private void Update()
    {
        if (!isDragging)
        {
            transform.Rotate(0, Input.GetAxisRaw("Horizontal") * 100.0f * Time.deltaTime, 0);
        }
        if (Input.GetAxisRaw("Vertical") != 0)
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
        else
        {
            isWalking = false;
            isRunning = false;
            ChooseAnimation();
        }

        if (isgrounded == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Jump")))
        {
            // Préparation du saut 
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumSpeed.y;
            // Saut
            gameObject.GetComponent<Rigidbody>().velocity = jumSpeed;
            isgrounded = false;

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
            }else if (isWalking)
            {
                Walk();
            }
            else
            {
                Stay();
            }
        }

    // Controler Véhicule
    public GameObject vehicule;
    public GameObject cameraTruck;
    public GameObject FX_Emplacement; 

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "FireTruck" && (Input.GetButton("Fire2") || Input.GetButton("F")))
        {
            gameObject.SetActive(false);
            FX_Emplacement.SetActive(false); 
            vehicule.GetComponent<VehiculeController>().enabled = true;
            vehicule.GetComponent<AudioSource>().enabled = true; 
            cameraTruck.SetActive(true); 
            this.transform.GetChild(0);

        }
    }


}
