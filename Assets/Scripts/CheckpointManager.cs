using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private Checkpoint[] checkpoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkpoints = FindObjectsByType<Checkpoint>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
    void Update()
    {
        bool allEntered = true;

        foreach (var point in checkpoints)
        {
            if (!point.hasEntered)
            {
                allEntered = false;
            }
        }

        if (allEntered)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
