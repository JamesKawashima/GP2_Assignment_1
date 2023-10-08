using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_jump : MonoBehaviour
{
    public GameManager gameManager;
    public float respawnTime = 30f;

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
            gameManager.SetDoubleJump(true);
            gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        Invoke("ReEnable", respawnTime);
    }

    void ReEnable()
    {
        gameObject.SetActive(true);
    }
}
