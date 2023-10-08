using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_condition : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.SaveScore();
            gameManager.ResetLvl();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
