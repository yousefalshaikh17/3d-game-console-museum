using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PopupController : MonoBehaviour
{
    //public PlayableDirector stopDirector;
    private PlayableDirector director;
    private bool screenActive;
    private Transform mainCamera;

    public PlayableAsset screenEnablePlayable;
    public PlayableAsset screenDisablePlayable;

    private float distance;
    public float maximumDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        if (enabled)
        {
            if (getDistanceToCamera() > maximumDistance)
            {
                closeScreen();
            }
        }
    }

    public float getDistanceToCamera()
    {
        return Vector3.Distance(transform.position, mainCamera.position);
    }

    public void openScreen()
    {
        if (!screenActive && getDistanceToCamera() <= maximumDistance)
        {
            director.playableAsset = screenEnablePlayable;
            director.Play();
            screenActive = true;
        }
    }

    void closeScreen()
    {
        if (screenActive)
        {
            director.playableAsset = screenDisablePlayable;
            director.Play();
            screenActive = false;

        }
    }

    void OnBecameInvisible()
    {
        closeScreen();
    }

}
