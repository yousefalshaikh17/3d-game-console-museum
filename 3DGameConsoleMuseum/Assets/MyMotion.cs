using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMotion : MonoBehaviour
{
    private bool walking = false;
    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (walking)
        {
            transform.position += Camera.main.transform.forward * .5f * Time.deltaTime;
        }

        if (transform.position.y < -10)
            transform.position = spawnPoint;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Contains("plane"))
            {
                walking = false;
            } else {
                walking = true;
                }
        }
    }
}
