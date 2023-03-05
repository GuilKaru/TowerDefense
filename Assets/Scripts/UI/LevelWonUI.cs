using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWonUI : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
