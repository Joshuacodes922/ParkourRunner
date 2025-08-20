using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverhandling : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;

    bool isInMenu;

    private void Awake()
    {
        gameOverUI.SetActive(false);

        //Change

        isInMenu = false;
        cursorManagment();
    }

    private void Update()
    {
        cursorManagment();
    }
    public void death()
    {
        Time.timeScale = 0f;
        isInMenu = true;
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    void cursorManagment()
    {
        if (!isInMenu)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
