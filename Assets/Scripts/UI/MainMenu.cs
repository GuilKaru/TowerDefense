using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu UI")]
    [SerializeField] private GameObject mainMenu;

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
