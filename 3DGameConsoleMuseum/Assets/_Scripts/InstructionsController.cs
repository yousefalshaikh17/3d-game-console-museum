using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsController : MonoBehaviour
{
    private Transform mainCamera;
    public PlayerController characterMovementControls;
    public LookTeleport characterTeleportControls;
    public float distanceFromCamera = 1.5f;

    private Vector3 cameraForward;
    //private float cachedSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
        //cachedSpeed = characterMovementControls.speed;
        //characterMovementControls.speed = 0;
    }
    

    public void Update()
    {
        cameraForward = mainCamera.TransformDirection(Vector3.forward);
        cameraForward.y = 0;
        transform.position = mainCamera.position + (cameraForward * distanceFromCamera);
        transform.LookAt(mainCamera.position);
        transform.Rotate(0, 180f, 0);
    }
    public void activatePlayer()
    {
        //characterMovementControls.speed = cachedSpeed;
        characterMovementControls.enabled = true;
        characterTeleportControls.enabled = true;
        Destroy(gameObject);
    }
}
