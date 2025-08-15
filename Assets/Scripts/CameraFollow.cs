using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 offset;

    void Start()
    {
        // Store initial offset between camera and player
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Create a rotation only around the Y axis
        Quaternion rotation = Quaternion.Euler(0f, player.eulerAngles.y + 90, 0f);

        // Rotate the offset based on player's Y-axis
        Vector3 rotatedOffset = rotation * offset;

        // Set the new position with rotated offset
        transform.position = player.position + rotatedOffset;

        Vector3 lookAtPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookAtPosition);
    }
}
