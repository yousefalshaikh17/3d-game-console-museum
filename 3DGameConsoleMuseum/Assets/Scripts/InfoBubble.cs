using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

// Put on info bubble.
public class InfoBubble : MonoBehaviour
{
    // Assign directly rather than use Find()
    public TextMeshProUGUI infoText;
    public Text titleText;
    public Image image;
    public Image UIImage;
    public PlayableDirector director;

    private Transform playerCamera;
    public float rotationSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        // Better to initialize early rather than call it every frame
        playerCamera = Camera.main.transform;
        faceCamera();
    }

    public void faceCamera()
    {
        if (playerCamera)
            transform.rotation = getTargetRotation();
    }

    private Quaternion getTargetRotation()
    {
        Vector3 direction = (playerCamera.position - transform.position).normalized;
        Quaternion rotate = Quaternion.LookRotation(direction, Vector3.up);
        rotate = Quaternion.Euler(0, rotate.eulerAngles.y + 180f, 0);
        return rotate;
    }


    // Update is called once per frame ONLY if it is active.
    void Update()
    {
        //infoText.text = "I am a cube.";
        /*
        infoBubble.LookAt(camera.position);
        */
        transform.rotation = Quaternion.Slerp(transform.rotation, getTargetRotation(), rotationSpeed * Time.deltaTime);

        if (Vector3.Distance(playerCamera.position, transform.position) > InfoBubbleManager.maximumDistance)
        {
            InfoBubbleManager.main.recallBubble();
        }
    }

    public void updateBubbleText(MuseumObject museumObject)
    {
        infoText.text = museumObject.description;
        //infoText.fontSize = museumObject.textSize;
        //infoText.resizeTextMaxSize = museumObject.textSize;
        //infoText.fontSizeMax = museumObject.textSize;
        titleText.text = museumObject.objectName;
        image.sprite = museumObject.sprite;
        UIImage.color = museumObject.color;
        director.Play();
    }
}
