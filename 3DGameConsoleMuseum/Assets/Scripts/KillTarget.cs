using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTarget : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f;
    public int score;
    private float countDown;

    void Start () {
        score = 0;
        countDown = timeToSelect;
    }

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray (camera.position, camera.rotation *Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit) && (hit.collider.gameObject== target)) {
            if (countDown > 0.0f) {
                // on target
                countDown -= Time.deltaTime;
                // print (countDown);
                hitEffect.transform.position = hit.point;hitEffect.Play();
            }
            else {
                // killed
                Instantiate( killEffect, target.transform.position,target.transform.rotation );
                score += 1;
                countDown = timeToSelect;SetRandomPosition();
                Debug.Log("Killed!");
            }
        } else {
            // reset
            countDown = timeToSelect;
            hitEffect.Stop();
        }
    }

    void SetRandomPosition() {
        float x = Random.Range (-5.0f, 5.0f);
        float z = Random.Range (-5.0f, 5.0f);
        target.transform.position = new Vector3 (x, 0.0f, z);
    }

}
