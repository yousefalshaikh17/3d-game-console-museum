using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBubbleManager : MonoBehaviour
{
    public InfoBubble infoBubble;
    [SerializeField] public static float maximumDistance = 3f;
    private Transform mainCamera;

    public static InfoBubbleManager main;

    void Start()
    {
        main = this;
        mainCamera = Camera.main.transform;
    }

    public void showBubble(MuseumObject museumObject)
    {
        if (infoBubble.transform.parent != museumObject.transform && Vector3.Distance(mainCamera.position, museumObject.transform.position) <= maximumDistance)
        {
            Debug.Log(Vector3.Distance(mainCamera.position, museumObject.transform.position));
            // Enable and position the bubble
            infoBubble.gameObject.SetActive(true);
            infoBubble.transform.SetParent(museumObject.transform);
            // Use the museum object's custom offset.
            infoBubble.transform.localPosition = museumObject.bubbleOffset;

            // Static orient the bubble to the player so it doesnt animate towards them.
            infoBubble.faceCamera();

            // Insert data from MuseumObject to the bubble.
            infoBubble.updateBubbleText(museumObject);
        } else
        {
            recallBubble();
        }
    }

    public float getBubbleAndPlayerDistanace()
    {
        return Vector3.Distance(mainCamera.position, infoBubble.transform.position);
    }

    public void recallBubble()
    {
        infoBubble.gameObject.SetActive(false);
        infoBubble.transform.SetParent(transform);
    }
}
