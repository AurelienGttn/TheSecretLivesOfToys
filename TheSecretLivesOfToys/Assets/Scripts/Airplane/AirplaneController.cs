using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AirplaneController : MonoBehaviour
{
    private int gameOver = 0; // Turn on and off the airplane code. Game over
    private float crashForce = 0f; // When gameOver we need a force to let the airplane crash

    // Rotation and position of our airplane
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private float rotationZ = 0.0f;
    private float positionX = 0.0f;
    private float positionY = 0.0f;
    private float positionZ = 0.0f;

    [SerializeField] private float minimumSpeed = 595;                   // Minimum speed for take off 
    [SerializeField] private float maximumSpeed = 800;                   // Maximum speed
    [SerializeField] private float neutralSpeed = 700;                   // Speed in the air when not accelerating nor decelerating
    [SerializeField] private float enginePower = 240;                    // How fast we accelerate/decelerate
    private float speed = 0.0f;                                         // Speed variable is the speed
    private float upLift = 0.0f;                                        // Uplift to take off
    [SerializeField] private float pseudoGravitation = -0.3f;            // Downlift for driving through landscape

    private float rightLeftSoft = 0.0f;                 // Variable for soft curveflight
    private float rightLeftSoftAbs = 0.0f;              // Positive rightLeftSoft Variable 

    private float diveSalto = 0.0f;                     // Blocks the forward salto
    private float diveBlocker = 0.0f;                   // Blocks sideways stagger flight while dive

    private Rigidbody m_Rigidbody;
    public static bool PlaneScene = false;  

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (Input.GetButton("E"))
        {
            SceneManager.LoadScene("MissionCompleted");
            PlaneScene = true;
        }


        //----------------- Game over -----------------//

        //Restart when gameOver = 2
        if (gameOver == 2 && (Input.GetKey("enter")) || gameOver == 2 && (Input.GetKey("return")))
        {
            gameOver = 0;
            m_Rigidbody.useGravity = false;
            transform.position = new Vector3(0, 1.67f, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        // Physics stuff when gameOver ==1
        if (gameOver == 1)
        {
            m_Rigidbody.AddRelativeForce(0, 0, crashForce);
            gameOver = 2;
        }


        //---------------------#####     Flying Maincode     #####---------------------//

        // Code is active when gameOver = 0
        if (gameOver == 0)
        {
            // Turn variables to rotation and position of the object
            rotationX = transform.eulerAngles.x;
            rotationY = transform.eulerAngles.y;
            rotationZ = transform.eulerAngles.z;
            positionX = transform.position.x;
            positionY = transform.position.y;
            positionZ = transform.position.z;


            //----------------- Rotation of the airplane -----------------//

            // Up Down, limited to a minimum speed
            if ((Input.GetAxis("Vertical") <= 0) && ((speed > minimumSpeed)))
            {
                transform.Rotate((Input.GetAxis("Vertical") * Time.deltaTime * 80), 0, 0);
            }
            // Special case dive above 90 degrees
            if ((Input.GetAxis("Vertical") > 0) && ((speed > minimumSpeed)))
            {
                transform.Rotate((0.8f - diveSalto) * (Input.GetAxis("Vertical") * Time.deltaTime * 80), 0, 0);
            }

            // Left Right at the ground	
            if (GroundTrigger.triggered)
                transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * 30, 0, Space.World);
            // Left Right in the air
            else
                transform.Rotate(0, Time.deltaTime * 100 * rightLeftSoft, 0, Space.World);

            // Tilt multiplied with minus 1 to go into the right direction	
            // Tilt only happens in the air
            if (!GroundTrigger.triggered)
                transform.Rotate(0, 0, Time.deltaTime * 100 * (1.0f - rightLeftSoftAbs - diveBlocker) * Input.GetAxis("Horizontal") * -1.0f);

            //----------------- Pitch and Tilt calculations -----------------//

            //variable rightLeftSoft + rightLeftSoftabs

            //Soft rotation calculation -----This prevents the airplaine to fly to the left while it is still tilted to the right
            if ((Input.GetAxis("Horizontal") <= 0) && (rotationZ > 0) && (rotationZ < 90))
                rightLeftSoft = rotationZ * 2.2f / 100 * -1f;           // to the left
            if ((Input.GetAxis("Horizontal") >= 0) && (rotationZ > 270))
                rightLeftSoft = 7.92f - rotationZ * 2.2f / 100;       // to the right
            
            //Limit rightLeftSoft so that the switch isn`t too hard when flying overhead
            if (rightLeftSoft > 1)
                rightLeftSoft = 1;
            if (rightLeftSoft < -1)
                rightLeftSoft = -1;

            // Precision problem rightLeftSoft to zero
            if ((rightLeftSoft > -0.01f) && (rightLeftSoft < 0.01f))
                rightLeftSoft = 0;

            // Retrieves positive rightLeftSoft variable 
            rightLeftSoftAbs = Mathf.Abs(rightLeftSoft);

            //----------------- Calculations Block salto forward -----------------//

            // Variable diveSalto
            // Dive salto forward blocking
            if (rotationX < 90)
                diveSalto = rotationX / 100.0f; 
            if (rotationX > 90)
                diveSalto = -0.2f;              

            // Variable diveBlocker
            // Blocks sideways stagger flight while dive
            if (rotationX < 90) diveBlocker = rotationX / 200.0f;
            else diveBlocker = 0;

            //----------------- Everything rotate back -----------------//

            // Rotate back when key wrong direction 
            if ((rotationZ < 180) && (Input.GetAxis("Horizontal") > 0))
                transform.Rotate(0, 0, rightLeftSoft * Time.deltaTime * 80);
            if ((rotationZ > 180) && (Input.GetAxis("Horizontal") < 0))
                transform.Rotate(0, 0, rightLeftSoft * Time.deltaTime * 80);

            //Rotate back in Z axis general, limited by no horizontal button pressed
            if (!Input.GetButton("Horizontal"))
            {
                if ((rotationZ < 135)) transform.Rotate(0, 0, rightLeftSoftAbs * Time.deltaTime * -100f);
                if ((rotationZ > 225)) transform.Rotate(0, 0, rightLeftSoftAbs * Time.deltaTime * 100f);
            }

            // Rotate back X axis
            if ((!Input.GetButton("Vertical")) && !GroundTrigger.triggered)
            {
                if ((rotationX > 0) && (rotationX < 180)) transform.Rotate(Time.deltaTime * -50, 0, 0);
                if ((rotationX > 0) && (rotationX > 180)) transform.Rotate(Time.deltaTime * 50, 0, 0);
            }

            //----------------- Speed driving and flying -----------------//

            // Speed
            transform.Translate(0, 0, speed / 20 * Time.deltaTime);

            // We need a minimum speed limit in the air. We limit again with the groundtrigger.triggered variable

            // Input accelerate and decelerate on ground
            if (GroundTrigger.triggered && Input.GetButton("Fire1") && (speed < maximumSpeed))
                speed += Time.deltaTime * enginePower;
            if (GroundTrigger.triggered && Input.GetButton("Fire2") && (speed > 0))
                speed -= Time.deltaTime * enginePower;

            // Input Accellerate and deccellerate in the air
            if (!GroundTrigger.triggered && Input.GetButton("Fire1") && (speed < maximumSpeed))
                speed += Time.deltaTime * enginePower;
            if (!GroundTrigger.triggered && Input.GetButton("Fire2") && (speed > minimumSpeed))
                speed -= Time.deltaTime * enginePower;

            if (speed < 0) speed = 0; //floatingpoint calculations makes a fix necessary so that speed cannot be below zero

            //Another speed floatingpoint fix:
            if (!GroundTrigger.triggered && !Input.GetButton("Fire1") && !Input.GetButton("Fire2") && (speed > neutralSpeed - 5) && (speed < neutralSpeed + 5))
                speed = neutralSpeed;

            //----------------- Uplift -----------------//

            //When we don`t accelerate or decelerate we want to go to a neutral speed in the air. With this speed it has to stay at a neutral height. 
            //Above this value the airplane has to climb, with a lower speed it has to sink. That way we are able to takeoff and land.

            //This code resets the speed to neutralSpeed when there is no acceleration or deceleration
            if (!Input.GetButton("Fire1") && !Input.GetButton("Fire2") && (speed > minimumSpeed) && (speed < neutralSpeed))
                speed += Time.deltaTime * enginePower;
            if (!Input.GetButton("Fire1") && !Input.GetButton("Fire2") && (speed > minimumSpeed) && (speed > neutralSpeed))
                speed -= Time.deltaTime * enginePower;

            // Uplift
            transform.Translate(0, upLift * Time.deltaTime / 10.0f, 0);

            // Calculate uplift
            upLift = -neutralSpeed + speed;
            
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

    // ----------------------------------------------  Gameover activating ----------------------------------------------------------------

    //When our airplane is in the air (!onGround), and touches the ground with something different than 
    //the wheels (groundtrigger primitive) it will count as crash.
    //We need to convert the speed into a force so that we can let our airplane collide

    private void OnCollisionEnter(Collision collision)
    {
        if (!GroundTrigger.triggered)
        {
            GroundTrigger.triggered = true;
            crashForce = speed * 10000;
            speed = 0;
            gameOver = 1;
            m_Rigidbody.useGravity = true;
        }
    }
}