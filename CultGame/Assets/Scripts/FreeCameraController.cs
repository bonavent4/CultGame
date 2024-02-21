using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    public float movementSpeed = 5f; // Speed of camera movement
    //public float rotationSpeed = 3f; // Speed of camera rotation
    public float dragSpeed = 2f; // Speed of camera dragging

    private bool isDragging = false;
    private Vector3 dragOrigin;

    public KeyCode moveForwardKey = KeyCode.W;
    public KeyCode moveBackwardKey = KeyCode.S;
    public KeyCode strafeLeftKey = KeyCode.A;
    public KeyCode strafeRightKey = KeyCode.D;
    //public KeyCode rotateLeftKey = KeyCode.Q;
    //public KeyCode rotateRightKey = KeyCode.E;
    [SerializeField] AudioSource clickSound;
    [SerializeField] float[] MaxPosition;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickSound.Play();
        }
        HandleMouseInput();

        // Camera movement controls
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(moveForwardKey) && transform.position.z < MaxPosition[0])
            movement += transform.parent.forward;
        if (Input.GetKey(moveBackwardKey) && transform.position.z > MaxPosition[1])
            movement -= transform.parent.forward;
        if (Input.GetKey(strafeLeftKey) && transform.position.x > MaxPosition[2])
            movement -= transform.parent.right;
        if (Input.GetKey(strafeRightKey) && transform.position.x < MaxPosition[3])
            movement += transform.parent.right;
        movement.Normalize();
        movement *= movementSpeed * Time.deltaTime;
        transform.position += movement;

        // Camera rotation controls
        /*if (Input.GetKey(rotateLeftKey))
            transform.Rotate(Vector3.up, -rotationSpeed);
        if (Input.GetKey(rotateRightKey))
            transform.Rotate(Vector3.up, rotationSpeed);*/
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(1)) // Left mouse button
        {
            isDragging = true;
            dragOrigin = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(1)) // Left mouse button released
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(-pos.x * dragSpeed, 0, -pos.y * dragSpeed);
         




            transform.Translate(move, Space.World);
            dragOrigin = Input.mousePosition;

            if (transform.position.z > MaxPosition[0])
                transform.position = new Vector3(transform.position.x, transform.position.y, MaxPosition[0]);
            if (transform.position.z < MaxPosition[1])
                transform.position = new Vector3(transform.position.x, transform.position.y, MaxPosition[1]);
            if (transform.position.x < MaxPosition[2])
                transform.position = new Vector3(MaxPosition[2], transform.position.y, transform.position.z);
            if (transform.position.x > MaxPosition[3])
                transform.position = new Vector3(MaxPosition[3], transform.position.y, transform.position.z);
        }
    }
}



