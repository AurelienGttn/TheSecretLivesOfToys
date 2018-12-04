using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AirplaneController : MonoBehaviour
{
    public float minimumSpeed = 595;                                    // Minimum speed for take off 
    public float maximumSpeed = 800;                                    // Maximum speed
    public float neutralSpeed = 700;                                    // Speed in the air when not accelerating nor decelerating
    [SerializeField] private float enginePower = 240;                   // How fast we accelerate/decelerate

    [SerializeField] private float pitchSpeed = 80;                     // How fast we can go up and down
    [SerializeField] private float airTurnSpeed = 100;                  // How fast we can turn right and left in the air
    private float groundTurnSpeed;                                      // How fast we can turn right and left on the ground (about 0.3*airTurnSpeed)
    [SerializeField] private float reverseRotationSpeed = 80;           // How fast the airplane can reverse its direction (going to the left when oriented to the right)
    [SerializeField] private float horizontalRotateBackSpeed = 100;     // How fast the airplane can go back to a null rotation on Z axis
    [SerializeField] private float verticalRotateBackSpeed = 50;        // How fast the airplane can go back to a null rotation on X axis

    [SerializeField] private float pseudoGravitation = -0.3f;           // Downlift for driving on the ground

    private float diveSalto;                                            // Blocks the forward salto, min 0, max 1
    private float diveBlocker;                                          // Blocks sideways stagger flight while dive

    private bool gameOver = false;                                           // Turn on and off the airplane code. Game over
    [SerializeField] private ParticleSystem crashExplosion;

    // Rotation of our airplane
    private float rotationX;
    private float rotationZ;

    public float speed;                                                 // Current speed of the airplane
    private float upLift;                                               // Uplift to take off

    private float rightLeftSoft;                                        // Variable for soft curve flight
    private bool isLanding;                                             // Override controls during landing cutscene
    private Rigidbody m_Rigidbody;
    public GameObject panelCrashAvion;
    public GameObject crossHair;

    public AudioSource globalMusic;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        // The airplane turns slower on the ground than in the air
        groundTurnSpeed = airTurnSpeed * 0.3f;
        isLanding = false;
    }

    private void FixedUpdate()
    {
        //----------------- Game over -----------------//
        

        // Physics stuff when gameOver ==1
        if (gameOver)
        {
            transform.Rotate(Vector3.up, 200 * Time.deltaTime);
            globalMusic.Stop();
            StartCoroutine(WaitCrash());
        }


        //---------------------#####     Flying Maincode     #####---------------------//

        // Code is active when gameOver is false
        if (!gameOver)
        {
            // Turn variables to rotation and position of the object
            rotationX = transform.eulerAngles.x;
            rotationZ = transform.eulerAngles.z;

            //----------------- Pitch and Tilt calculations -----------------//

            //variable rightLeftSoft + rightLeftSoftabs

            //Soft rotation calculation -----This prevents the airplaine to fly to the left while it is still tilted to the right
            if (Input.GetAxis("Horizontal") <= 0 && rotationZ > 0 && rotationZ < 90)
                rightLeftSoft = rotationZ * 2.2f / 100 * -1f;           // to the left
            if (Input.GetAxis("Horizontal") >= 0 && rotationZ > 270)
                rightLeftSoft = 7.92f - rotationZ * 2.2f / 100;       // to the right

            //Limit rightLeftSoft so that the switch isn`t too hard when flying overhead
            Mathf.Clamp(rightLeftSoft, -1.0f, 1.0f);

            // Precision problem rightLeftSoft to zero
            if ((rightLeftSoft > -0.01f) && (rightLeftSoft < 0.01f))
                rightLeftSoft = 0;

            // Retrieves positive rightLeftSoft variable 
            float rightLeftSoftAbs = Mathf.Abs(rightLeftSoft);


            //----------------- Calculations Block salto forward -----------------//

            // Variable diveSalto
            // Dive salto forward blocking
            if (rotationX < 90)
                diveSalto = rotationX / 100.0f;
            if (rotationX > 90)
                diveSalto = -0.2f;

            // Variable diveBlocker
            // Blocks sideways stagger flight while dive
            if (rotationX < 90)
                diveBlocker = rotationX / 200.0f;
            else
                diveBlocker = 0;


            //----------------- Rotation of the airplane -----------------//

            // Up Down, limited to a minimum speed
            if (Input.GetAxis("Vertical") <= 0 && speed > minimumSpeed)
                transform.Rotate((Input.GetAxis("Vertical") * Time.deltaTime * pitchSpeed), 0, 0);

            // Special case dive above 90 degrees
            if (Input.GetAxis("Vertical") > 0 && speed > minimumSpeed)
                // Make sure the diveSalto correction isn't too high or too low
                transform.Rotate(Mathf.Clamp((1.0f - diveSalto), 0.0f, 1.0f) *
                    Input.GetAxis("Vertical") * Time.deltaTime * pitchSpeed, 0, 0);

            // Player can't turn during landing cutscene
            if (!isLanding)
            {
                // Left Right at the ground	
                if (GroundTrigger.triggered)
                    transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * groundTurnSpeed, 0, Space.World);
                // Left Right in the air
                else
                    transform.Rotate(0, Time.deltaTime * airTurnSpeed * rightLeftSoft, 0, Space.World);


                // Tilt multiplied with minus 1 to go into the right direction	
                // Turn correction must not go below 0 or over 1
                // Tilt only happens in the air
                if (!GroundTrigger.triggered)
                    transform.Rotate(0, 0,
                        Time.deltaTime * airTurnSpeed * (1.0f - Mathf.Clamp(rightLeftSoftAbs - diveBlocker, 0.0f, 1.0f)) *
                        Input.GetAxis("Horizontal") * -1.0f);
            }

            //----------------- Everything rotate back -----------------//

            // Turn back to opposite direction
            if (rotationZ < 180 && Input.GetAxis("Horizontal") > 0)
                transform.Rotate(0, 0, rightLeftSoft * Time.deltaTime * reverseRotationSpeed);
            if (rotationZ > 180 && Input.GetAxis("Horizontal") < 0)
                transform.Rotate(0, 0, rightLeftSoft * Time.deltaTime * reverseRotationSpeed);

            //Rotate back in Z axis general, limited by no horizontal button pressed
            if (!Input.GetButton("Horizontal"))
            {
                if (rotationZ < 135)
                    transform.Rotate(0, 0, rightLeftSoftAbs * Time.deltaTime * -horizontalRotateBackSpeed);
                if (rotationZ > 225)
                    transform.Rotate(0, 0, rightLeftSoftAbs * Time.deltaTime * horizontalRotateBackSpeed);
            }

            // Rotate back X axis
            if (!Input.GetButton("Vertical") && !GroundTrigger.triggered)
            {
                if (rotationX > 0 && rotationX < 180)
                    transform.Rotate(Time.deltaTime * -verticalRotateBackSpeed, 0, 0);
                if (rotationX > 0 && rotationX > 180)
                    transform.Rotate(Time.deltaTime * verticalRotateBackSpeed, 0, 0);
            }


            //----------------- Speed driving and flying -----------------//

            // Speed
            transform.Translate(0, 0, speed / 20 * Time.deltaTime);

            // We need a minimum speed limit in the air. We limit again with the groundtrigger.triggered variable

            // Accelerate and decelerate on ground
            if (GroundTrigger.triggered && Input.GetButton("Fire3") && !Input.GetButton("Fire2") && speed < maximumSpeed)
                speed += Time.deltaTime * enginePower;
            if (GroundTrigger.triggered && Input.GetButton("Fire2") && !Input.GetButton("Fire3") && speed > 0)
                speed -= Time.deltaTime * enginePower;

            // Accelerate and decelerate in the air
            if (!GroundTrigger.triggered && Input.GetButton("Fire3") && !Input.GetButton("Fire2") && speed < maximumSpeed)
                speed += Time.deltaTime * enginePower;
            else if (!GroundTrigger.triggered && Input.GetButton("Fire2") && !Input.GetButton("Fire3") && speed > minimumSpeed)
                speed -= Time.deltaTime * enginePower;

            if (speed < 0)
                speed = 0; // Floatin point calculations make a fix necessary so that speed cannot be below zero

            // Another speed floating point fix:
            if (!GroundTrigger.triggered && !Input.GetButton("Fire3") && !Input.GetButton("Fire2")
                && (speed > neutralSpeed - 5) && (speed < neutralSpeed + 5))
                speed = neutralSpeed;


            //----------------- Uplift -----------------//

            // When we don`t accelerate or decelerate we want to go to a neutral speed in the air. 
            // With this speed it has to stay at a neutral height. 
            // Above this value the airplane has to climb, with a lower speed it has to sink. That way we are able to takeoff and land.

            //This code resets the speed to neutralSpeed when there is no acceleration or deceleration
            if (!Input.GetButton("Fire3") && !Input.GetButton("Fire2") && speed > minimumSpeed && speed < neutralSpeed)
                speed += Time.deltaTime * enginePower;
            if (!Input.GetButton("Fire3") && !Input.GetButton("Fire2") && speed > minimumSpeed && speed > neutralSpeed)
                speed -= Time.deltaTime * enginePower;

            // Uplift
            transform.Translate(0, upLift * Time.deltaTime / 30.0f, 0);

            // Calculate uplift
            if (speed < neutralSpeed)
                upLift = -neutralSpeed + speed;
            else
                upLift = 0;

            //We don`t want downlift. So when the uplift value lower zero we set it to 0
            if (GroundTrigger.triggered && (upLift < 0.0f))
                upLift = 0.0f;

            //----------------- Driving around -----------------//

            // Special case drive across landscape; we need something like pseudo gravitation
            // And we align the airplane on the ground
            // We use sensor objects for that

            // Ground driving is up to variable minimumSpeed
            if (speed < minimumSpeed)
            {
                if (!SensorFront.sensorFront && SensorRear.sensorRear)
                    transform.Rotate(Time.deltaTime * 20, 0, 0);
                if (SensorFront.sensorFront && !SensorRear.sensorRear)
                    transform.Rotate(Time.deltaTime * -20, 0, 0);
                if (SensorFrontUp.sensorFrontUp)
                    transform.Rotate(Time.deltaTime * -20, 0, 0);
                // Pseudo gravity 
                if (!GroundTrigger.triggered)
                    transform.Translate(0, pseudoGravitation * Time.deltaTime / 10.0f, 0);
            }
        }
    }

    //-----------------  Gameover activating -----------------//

    // When our airplane is in the air (!onGround), and touches the ground with something different than 
    // the wheels (groundtrigger primitive) it will count as crash.

    private void OnCollisionEnter(Collision collision)
    {
        // Should not happen if the airplane is not active
        if (!enabled)
            return;

        if (!GroundTrigger.triggered && !collision.gameObject.name.StartsWith("Bullet"))
        {
            GroundTrigger.triggered = true;
            speed = 0;
            gameOver = true;
            m_Rigidbody.useGravity = true;
            ParticleSystem crashExplosionClone = Instantiate(crashExplosion, transform.position, Quaternion.identity);
            crashExplosionClone.transform.localScale = transform.localScale;
        }
    }

    // Wait a little before showing the crash panel
    private IEnumerator WaitCrash()
    {
        yield return new WaitForSeconds(2f);
        crossHair.SetActive(false); 
        panelCrashAvion.SetActive(true);
        Time.timeScale = 0f; 

    }

    // Make the plane land by overriding the speed
    public void Land()
    {
        isLanding = true;
        speed = 500;
        StartCoroutine(DecreaseAirplaneSpeed());
        transform.rotation = Quaternion.identity;
    }

    // Decrease speed over time to land
    private IEnumerator DecreaseAirplaneSpeed()
    {
        if (speed > 0)
            speed -= 40;
        else
            speed = 0;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(DecreaseAirplaneSpeed());
    }
}