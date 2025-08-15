using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
