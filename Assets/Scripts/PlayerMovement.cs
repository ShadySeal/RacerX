using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float verticalInput;
    private float mouseInputX;

    private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float turnAcceleration;
    [SerializeField] private float distanceFromGround;
    [SerializeField] private float angleSpeed = 15f;

    private Vector3 targetPosition;
    private Vector3 deskUp = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        mouseInputX = Input.GetAxisRaw("Mouse X");

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            targetPosition = new Vector3(transform.position.x, hit.point.y + distanceFromGround, transform.position.z);

            deskUp = hit.normal;
        }

        transform.position = targetPosition;
        transform.up = Vector3.Slerp(transform.up, deskUp, angleSpeed * Time.deltaTime);

        speed = rb.linearVelocity.magnitude;
    }

    private void FixedUpdate()
    {
        rb.AddForce(rb.transform.TransformDirection(Vector3.forward) * verticalInput * acceleration, ForceMode.VelocityChange);
        rb.AddTorque(rb.transform.up * turnAcceleration * mouseInputX, ForceMode.VelocityChange);
    }
}