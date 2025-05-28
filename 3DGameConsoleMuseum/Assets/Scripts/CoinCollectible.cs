using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class CoinCollectible : MonoBehaviour
{

    public float collectDistance = 3;
    public GameObject collectEffect;
    public GameObject parentDestroy;

    public float rotationSpeed = 100.0f;
    private Transform mainCamera;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mainCamera = Camera.main.transform;
        SphereCollider collider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotationSpeed != 0f)
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));

    }

    public void Collect()
    {
        if (Vector3.Distance(mainCamera.position, transform.position) < 3)
        {
            audioSource.Play();
            CoinGUIHandler.main.addCoin();
            if (collectEffect)
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            if (parentDestroy)
                Destroy(parentDestroy);
            else
                Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Collect();
        }
    }

}
