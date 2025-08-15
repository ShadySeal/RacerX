using TMPro;
using UnityEngine;

public class LapCount : MonoBehaviour
{
    private TextMeshProUGUI lapText;

    [SerializeField] private CheckpointManager checkpointManager;

    private void Start()
    {
        lapText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        int currentLap = checkpointManager.lapCount;
        lapText.text = $"<color=#FFCC00>{currentLap}</color>/2";
    }
}
