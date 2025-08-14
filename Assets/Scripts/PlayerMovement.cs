using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;

    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float turnAcceleration = 5f;
    [SerializeField] private float turnSpeed = 50f;
    [SerializeField] private float distanceFromGround = 2f;
    [SerializeField] private float angleSpeed = 15f;

    private Vector3 deskUp;
    private Vector3 currentVelocity;

    private float currentTurnSpeed = 0f;

    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // --- Forward/backward movement ---
        float targetSpeed = verticalInput * maxSpeed;
        float speedChange = acceleration * Time.deltaTime;
        float currentSpeed = currentVelocity.magnitude;
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, speedChange);
        currentVelocity = transform.forward * currentSpeed;

        Vector3 newPos = transform.position + currentVelocity * Time.deltaTime;

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            newPos.y = (hit.point + Vector3.up * distanceFromGround).y;
            deskUp = hit.normal;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        float targetTurnSpeed = horizontalInput * turnSpeed;
        currentTurnSpeed = Mathf.Lerp(currentTurnSpeed, targetTurnSpeed, turnAcceleration * Time.deltaTime);
        transform.Rotate(Vector3.up * currentTurnSpeed * Time.deltaTime);

        Vector3 forward = transform.forward;
        Quaternion slopeAlignedRotation = Quaternion.LookRotation(forward, deskUp);
        transform.rotation = Quaternion.Slerp(transform.rotation, slopeAlignedRotation, angleSpeed * Time.deltaTime);

        transform.position = newPos;
    }


}
