using UnityEngine;
public class LookSpawnTeleport : MonoBehaviour
{
    private Color saveColor;
    private GameObject currentTarget;

    // Reused to prevent fragmentation
    private Ray ray;
    private RaycastHit hit;
    private Transform playerCamera;
    private GameObject hitTarget;
    private CharacterController characterController;
    private Material material;
    private Color hiColor;

    private void Start()
    {
        playerCamera = Camera.main.transform;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        ray = new Ray(playerCamera.position, playerCamera.rotation * Vector3.forward);
        if (Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("TeleportSpawn")))
        {
            hitTarget = hit.collider.gameObject;
            if (hitTarget != currentTarget)
            {
                Unhighlight();
                Highlight(hitTarget);
            }
            if (Input.GetButtonDown("Fire1"))
            {
                characterController.Move((new Vector3(hitTarget.transform.position.x, 1.6f, hitTarget.transform.position.z)) - transform.position);
                //transform.position = new Vector3(hitTarget.transform.position.x, 1.6f, hitTarget.transform.position.z);
            }
        }
        else if (currentTarget != null)
        {
            Unhighlight();
        }
    }

    private void Highlight(GameObject target)
    {
        // Store material so that GetComponent doesnt have to be called multiple times.
        material = target.GetComponent<Renderer>().material;
        saveColor = material.color;

        hiColor = material.color;
        hiColor.a = 0.8f; // more opaque
        material.color = hiColor;

        currentTarget = target;
    }
    private void Unhighlight()
    {
        if (currentTarget != null)
        {
            //material = currentTarget.GetComponent<Renderer>().material;
            material.color = saveColor;
            currentTarget = null;
        }
    }
}