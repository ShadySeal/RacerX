using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private Checkpoint[] checkpoints;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private Timer timer;
    [SerializeField] private TextMeshProUGUI timerText;
    public int lapCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkpoints = FindObjectsByType<Checkpoint>(FindObjectsSortMode.None);

        Time.timeScale = 1;
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
            lapCount++;
            foreach (var point in checkpoints)
            {
                point.hasEntered = false;
                allEntered = false;
            }

            if (lapCount == 2)
            {
                victoryScreen.SetActive(true);
                Time.timeScale = 0;
                timer.timerIsRunning = false;
                timerText.text = timer.timeText.text;
            }
        }
    }
}
