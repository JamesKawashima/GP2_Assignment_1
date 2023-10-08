using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_score : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameManager.Instance;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            gameManager.AddScore();
            gameObject.SetActive(false);

        }
    }
}
