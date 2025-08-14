using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;

    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float distanceFromGround = 2f;
    [SerializeField] private float angleSpeed = 15f;
    [SerializeField] private float deceleration = 4f;

    private Vector3 deskUp;
    private Vector3 currentVelocity;

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 desiredVelocity = transform.forward * verticalInput * speed;

        currentVelocity = Vector3.Lerp(currentVelocity, desiredVelocity, deceleration * Time.deltaTime);
        Vector3 newPos = transform.position + currentVelocity * Time.deltaTime;

        Vector3 currentPosition = transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            newPos.y = (hit.point + Vector3.up * distanceFromGround).y;
            deskUp = hit.normal;

            currentPosition = transform.position;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        transform.position = newPos;

        if (horizontalInput != 0f)
        {
            float turn = horizontalInput * turnSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * turn);
        }

        Vector3 forward = transform.forward;
        Quaternion slopeAlignedRotation = Quaternion.LookRotation(forward, deskUp);
        transform.rotation = Quaternion.Slerp(transform.rotation, slopeAlignedRotation, angleSpeed * Time.deltaTime);
    }
}
