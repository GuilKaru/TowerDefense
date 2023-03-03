using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;
    public static bool gameWon;

    [Header("UI Managers")]
    public GameObject gameOverUI;
    public GameObject pauseUI;
    public GameObject gameWonUI;

    private void Awake()
    {
        gameWon = false;
        gameEnded = false;
    }

    /*private void Update()
    {
        if (gameEnded) return;

        if(gameWon)
        {
            gameEnded= true;
            gameWonUI.SetActive(true);
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if(PlayerStats.Lives <= 0) 
        {
            gameEnded = true;
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
    }*/

    public void TogglePause()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);

        //Stop or start time when pause is toggled
        if(pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
