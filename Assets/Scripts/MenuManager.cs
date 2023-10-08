using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    public void OnGameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnGameStop()
    {
        Application.Quit();
    }

    public void OnGameRestart()
    {
        gameManager.ResetLvl();
        SceneManager.LoadScene(1);
    }
}
