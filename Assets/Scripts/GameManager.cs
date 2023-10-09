using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Text scoreText;
    public Text jumpText;
    public GameObject player;
    // Write down your variables here
    public float Score;
    private float lvlFinalScore = 0;

    private void Awake()
    {

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        updateCanvas();

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
            updateCanvas();

        }
        if (SceneManager.GetActiveScene().buildIndex != 4)
        {
            jumpText = GameObject.FindGameObjectWithTag("Double").GetComponent<Text>();
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void SetScore()
    {
        Score = lvlFinalScore;
        updateCanvas();

    }

    public void AddScore()
    {
        Score += 50;
        updateCanvas();
    }

    public void ResetLvl()
    {
        SetScore();
        SetDoubleJump(false);
        updateCanvas();
    }

    public void SaveScore()
    {
        lvlFinalScore = Score;
        updateCanvas();
    }

    public void SetDoubleJump(bool jump)
    {
        player.GetComponent<CharacterMovement>().setDoubleJump(jump);
        updateCanvas();
    }

    public void updateCanvas()
    {
        scoreText.text = "Score: " + Score;

        if (player.GetComponent<CharacterMovement>().gotDoubleBoost)
        {
            jumpText.text = "YOU CAN JUMP!!!!!";
        }
        else
        {
            jumpText.text = "";
        }
    }
}
