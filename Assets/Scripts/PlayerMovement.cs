using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float verticalInput;
    private float mouseInputX;

    private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float turnAcceleration;

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

        speed = rb.linearVelocity.magnitude;
    }

    private void FixedUpdate()
    {
        rb.AddForce(rb.transform.TransformDirection(Vector3.forward) * verticalInput * acceleration, ForceMode.VelocityChange);
        rb.AddTorque(rb.transform.up * turnAcceleration * mouseInputX, ForceMode.VelocityChange);
    }
}