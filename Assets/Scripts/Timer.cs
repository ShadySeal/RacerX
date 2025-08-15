using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    [SerializeField] private float timeElapsed = 0f;
    public bool timerIsRunning = false;

    private void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            timeElapsed += Time.deltaTime;
            DisplayTime(timeElapsed);
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
