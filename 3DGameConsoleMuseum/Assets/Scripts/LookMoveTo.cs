using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMoveTo : MonoBehaviour
{
    public GameObject ground;
    Ray ray;
    RaycastHit[] hits;
    Transform camera;
    GameObject hitObject;

    void Awake()
    {
        camera = Camera.main.transform;
    }


    void Update () {
        //Debug.DrawRay (camera.position, camera.rotation *Vector3.forward * 100.0f);
        ray = new Ray (camera.position, camera.rotation *Vector3.forward);hits = Physics.RaycastAll (ray);
        for (int i = 0; i < hits.Length; i++) {
            RaycastHit hit = hits [i];
            hitObject = hit.collider.gameObject;
            if (hitObject == ground) {
                // Debug.Log ("Hit (x,y,z): " + hit.point.ToString("F2"));
                transform.position = hit.point;
            }
        }
    }
}
