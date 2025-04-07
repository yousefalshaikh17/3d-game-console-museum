/*
 * From lecture notes.
 * 
 * 
 */

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
public class CursorPositioner : MonoBehaviour { 
    private float defaultPosZ;

    private Transform camera;
    Ray ray;
    RaycastHit hit;

    void Start() 
    {
        /*
         * Set default pos based on the how it was before the script started.
         * This means the developer does not have to edit this script every time
         * the default distance needed to be changed.
         */
        defaultPosZ = transform.localPosition.z;
        camera = Camera.main.transform;

    }

    void Update() {
        // Ray cast from the camera to detect any objects with colliders in the way.
        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        if (Physics.Raycast(ray, out hit))
        {
            // if object is detected and it is closer than the reticle, then change to match distance.
            float newZPos;
            if (hit.distance <= defaultPosZ)
            {
                newZPos = Mathf.Max(0.5f, hit.distance - 0.2f);
            } else 
            {
                newZPos = defaultPosZ;
            }
            Debug.Log("New z: " + hit.distance);
            transform.localPosition = new Vector3(0, 0, newZPos);
        }
    }
}