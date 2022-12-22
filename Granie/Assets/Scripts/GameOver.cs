using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

    public void RetryButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void MenuExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}