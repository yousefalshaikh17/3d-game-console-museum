using UnityEngine;
public class LookTeleport : MonoBehaviour
{
    public GameObject target;
    public Renderer cylinderRenderer;
    public float requiredPressTime = 1;
    public string groundTag = "Ground";
    public float maximumDistance = 10f;
    public Vector3 cylinderOffset = new Vector3(0, 0.1f, 0);

    private bool isPressed = false;
    private float pressedTime = 0;


    // Keep local variables in class so memory doesnt have to be reallocated.
    private Transform mainCamera;
    private CharacterController characterController;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 targetPosition;
    private Color cylinderColor;
    private Material cylinderMaterial;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main.transform;
        cylinderMaterial = cylinderRenderer.material;
        cylinderColor = cylinderMaterial.color;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isPressed = true;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            if (target.activeSelf && pressedTime > requiredPressTime)
            {
                // done searching, teleport player
                GetComponent<CharacterController>().Move(target.transform.position - transform.position);
            }
            target.SetActive(false);
            isPressed = false;
            pressedTime = 0;

        }
        else if (isPressed)
        {
            ray = new Ray(mainCamera.position, mainCamera.rotation * Vector3.forward);
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == groundTag)
            {
                // If statement to check if already active, then activate.
                if (!target.activeSelf)
                    target.SetActive(true);

                // Calculate actual distance.
                if (hit.distance > maximumDistance)
                {
                    targetPosition = (-mainCamera.TransformDirection(Vector3.forward) * Mathf.Max((hit.distance - maximumDistance), 0));
                    targetPosition.y = 0;
                    targetPosition += hit.point;
                } else
                {
                    targetPosition = hit.point;
                }

                targetPosition+= cylinderOffset;

                // move target to look-at position
                target.transform.position = targetPosition;

                // Increment time
                pressedTime += Time.deltaTime;
            }
            else
            {
                // not looking a ground, reset target to player position
                target.transform.position = transform.position;
                // Stop stopwatch
                pressedTime = 0;
                // If statement to check if already deactivated, then deactivate.
                if (target.activeSelf)
                    target.SetActive(false);
            }
        }

        // Only perform action if active to save resources.
        if (target.activeSelf)
        {
            cylinderColor.a = Mathf.Min(pressedTime / requiredPressTime, 1);
            cylinderMaterial.color = cylinderColor;
        }


    }
}