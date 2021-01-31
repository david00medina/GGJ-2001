using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Playing Game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void LoadGame()
    {
        Debug.Log("Loading game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.LoadGame();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
