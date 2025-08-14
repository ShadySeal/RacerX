using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool hasEntered;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasEntered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasEntered = true;
        }
    }
}
