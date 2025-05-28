using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookAwayDetector : MonoBehaviour
{
    public float maximumDistance;
    public UnityEvent onTooFar;


    private Transform mainCamera;
    private float lastDistance;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        lastDistance = Vector3.Distance(transform.position, mainCamera.position);
        if (lastDistance > maximumDistance)
        {
            onTooFar.Invoke();
        }
    }
}
