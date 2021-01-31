using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameManager.IsPaused = !GameManager.IsPaused;
        }
    }

    public void Resume()
    {
        GameManager.IsPaused = !GameManager.IsPaused;
    }
    
    public void BackToMainMenu()
    {
        GameManager.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Save()
    {
        GameManager.SaveGame();
    }
}
