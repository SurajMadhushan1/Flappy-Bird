using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public Player player;



    public void Awake()
    {
        Pause();
    }


    public void Play()
    {
        gameOver.SetActive(false);
        playButton.SetActive(false);
        player.enabled = true;
        Time.timeScale = 1f;

        score = 0;
        scoreText.text = score.ToString();

        Pipe[] pipes = FindObjectsOfType<Pipe>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }


    }

    public void Pause()
    {


        Time.timeScale = 0f; // 0 mean game is not play, for that reason update method not executed
        player.enabled = false; // Disable player

    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore() {
        score++;

        scoreText.text = score.ToString();

    }
}
