using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private PlayerHealth test;
    private bool textdingetje;
    private bool checkIfPause;
    private bool ableToUnpause;
    public GameObject gameOverObjects;
    public GameObject pauseObjects;
    private bool restart;
    private gameState gs;

    enum gameState {playing, paused, gameover}

    void Start()
    {
        test = GameObject.Find("Player").GetComponent<PlayerHealth>();
        textdingetje = true;
        checkIfPause = false;
        gs = gameState.playing;
    }

    void Update()
    {
        switch (gs)
        {
            case gameState.playing:
                pauseObjects.SetActive(false);
                Time.timeScale = 1;

                if (Input.GetKeyDown("p"))
                {
                    gs = gameState.paused;
                }

                if (test.playerHealth == 0)
                {
                    gs = gameState.gameover;
                }

                break;

            case gameState.paused:
                pauseObjects.SetActive(true);
                Time.timeScale = 0;

                if (Input.GetKeyDown("p"))
                {
                    gs = gameState.playing;
                }

                if (Input.GetKeyDown("r"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                break;

                break;
            case gameState.gameover:
                gameOverObjects.SetActive(true);
                Time.timeScale = 0;

                if (Input.GetKeyDown("r"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                break;
        }
    }

    void CheckIfDead()
    {
        if (textdingetje == true && test.playerHealth == 0)
        {
            Debug.Log("ye dead");
            textdingetje = false;
            GameOver();
        }
    }

    void CheckIfPause()
    {
        if (Input.GetKeyDown("p"))
        {
            Debug.Log("test2");
            checkIfPause = true;
            Paused();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverObjects.SetActive(true);
        restart = true;
    }

    void Paused()
    {
        Debug.Log("pp");
        Time.timeScale = 0;
        pauseObjects.SetActive(true);
        ableToUnpause = true;
    }

    void Unpaused()
    {
        Time.timeScale = 1;
        pauseObjects.SetActive(false);
        ableToUnpause = false;
    }
}
