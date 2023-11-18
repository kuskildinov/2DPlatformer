using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private PlayerShoot player;

    private bool gamePaused;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
            {
                PauseGame(); 
                gamePaused = true;
            }
            else
            {
                ResumeGame();                
                gamePaused = false;
            }
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        PausePanel.SetActive(true);
        player.canShoot = false;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        player.canShoot = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void WinGame()
    {
        SceneManager.LoadScene(3);
    }
}
