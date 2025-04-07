using UnityEngine;

public class PlayerController : MonoBehaviour {

    public AudioClip[] footstepSounds;
    public AudioClip jumpSound;
    public AudioClip landSound;
    
    CharacterController characterController;
    Transform mainCamera;
    public bool lookingForward = false, isMoving = false;
    bool toggleForwardMotion, prevLookingForward;
    public float speed = 1.0f;
    public float voidHeight = -10f;

    public float jumpPower = 10f;
    private Vector3 currentVelocity = Vector3.zero;
    //private Vector3 jumpVelocity = Vector3.zero;
    private float ySpeed = 0f;
    private Vector3 cameraForward = Vector3.zero;
    private float cameraEulerX = 0;
    bool lookingUp, prevLookingUp;
    private float initialStepOffset;
    private float timeSinceLookDown = 0;
    private Vector3 lastGroundedPosition;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        //camera = GameObject.Find("Main Camera").transform; // Removed to prevent use of Find()
        mainCamera = Camera.main.transform;
        characterController = GetComponent<CharacterController>();
        initialStepOffset = characterController.stepOffset;
        audioSource = GetComponent<AudioSource>();
        
    }
    
    // Update is called once per frame
    void Update () {
        prevLookingForward = lookingForward;
        prevLookingUp = lookingUp;

        if (!prevLookingForward && !lookingForward)
        {
            timeSinceLookDown += Time.deltaTime;
        }

        //lookingForward = !((camera.transform.eulerAngles.x >= 15 && camera.transform.eulerAngles.x < 100));
        /*
        if (camera.transform.eulerAngles.x >= 15 &&camera.transform.eulerAngles.x < 100)
            lookingForward = false;
        else
            lookingForward = true;
        */

        /*
        if (lookingForward == true && prevLookingForward == false)
            startLookingForward = true;
        else
            startLookingForward = false;
        */
        cameraEulerX = mainCamera.eulerAngles.x;

        lookingUp = (cameraEulerX <= 310 && cameraEulerX > 260);

        if (
            (lookingForward = !(cameraEulerX >= 15 && cameraEulerX < 100) ) &&
            !prevLookingForward
            )
        {
            if (toggleForwardMotion || timeSinceLookDown < 1)
            {
                toggleForwardMotion = !toggleForwardMotion;
                timeSinceLookDown = 0;
            } else if (!toggleForwardMotion)
            {
                timeSinceLookDown = 0;
            }
        }
        //Debug.Log(lookingForward);



        //isMoving = lookingForward && toggleForwardMotion;
        /*
        if (lookingForward && toggleForwardMotion)
            isMoving = true;
        else
            isMoving = false;
        */

        if (characterController.isGrounded)
        {
            // Store most recent grounded position.
            lastGroundedPosition = transform.position;

            if (ySpeed < -1f)
            {
                playLandingSound();
            }

            ySpeed = -0.5f;
            characterController.stepOffset = initialStepOffset;
            if (!prevLookingUp && lookingUp)
            {
                jump();
            }
        } else
        {
            // Calculate gravity fall
            ySpeed += Physics.gravity.y * Time.deltaTime;
            // Disable step offset to prevent getting stuck on the wall while jumping.
            characterController.stepOffset = 0;

            if (transform.position.y < voidHeight)
            {
                characterController.Move(lastGroundedPosition - transform.position);
                Debug.Log("Brought player back.");
                return;
            }
        }

        
        currentVelocity = Vector3.zero;
        // Input Fire1 included to prevent conflicts and misinputs while performing other actions.
        if (isMoving = (lookingForward && toggleForwardMotion && !Input.GetButton("Fire1") && speed > 0))
        {
            cameraForward = mainCamera.TransformDirection(Vector3.forward);
            currentVelocity = (cameraForward * speed);
            playFootstepSounds();
        }
        currentVelocity.y = ySpeed;
        //Debug.Log(ySpeed);

        characterController.Move(Time.deltaTime * currentVelocity);

        /*
        if (jumpVelocity.y > 0)
        {
            currentVelocity += jumpVelocity;
            characterController.Move(currentVelocity * Time.deltaTime);
        } else if (!characterController.isGrounded || currentVelocity != zeroVector)
        {

            if (true)
            {
                // If velocity is 0, it will instead enforce gravity on non-grounded player.
                characterController.Move(currentVelocity * Time.deltaTime);
            }
            
        }
        */
        
    }

    void jump()
    {
        if (characterController.isGrounded)
        {
            print("Jump");
            playJumpSound();
            //characterController.Move(Vector3.up * 1000 * Time.deltaTime);
            //rigidBody.AddForce(Vector3.up * 10, ForceMode.Impulse);
            //jumpVelocity.y = jumpPower;
            ySpeed = jumpPower;
        } else
        {
            //Debug.Log("Character isn't grounded");
        }
    }

    void playJumpSound()
    {
        audioSource.clip = jumpSound;
        audioSource.Play();
    }

    void playLandingSound()
    {
        audioSource.clip = jumpSound;
        audioSource.Play();
    }

    void playFootstepSounds()
    {
        if (characterController.isGrounded && !audioSource.isPlaying)
        {
            audioSource.clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}