using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death_plane : MonoBehaviour
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
            gameManager.ResetLvl();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
