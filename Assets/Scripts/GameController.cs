using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private ShotgunScript ammoShotgun;
    private UziScript ammoUzi;
    private Transform playerTf;
    private bool textdingetje;
    private bool checkIfPause;
    private bool ableToUnpause;
    public GameObject gameOverObjects;
    public GameObject pauseObjects;
    public GameObject playingObjects;
    public GameObject shotgun;
    public GameObject uzi;
    public Text healthDisplay;
    public Text ammoDisplayShotgun;
    public Text ammoDisplayUzi;
    private bool restart;
    private gameState gs;
    private weaponSwitchingState ws;

    enum gameState {playing, paused, gameover}
    enum weaponSwitchingState {shotgun, uzi}

    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        ammoShotgun = GameObject.Find("shotgun").GetComponent<ShotgunScript>();
        ammoUzi = GameObject.Find("uzi").GetComponent<UziScript>();
        playerTf = GameObject.Find("Player").GetComponent<Transform>();
        textdingetje = true;
        checkIfPause = false;
        gs = gameState.playing;
        ws = weaponSwitchingState.shotgun;
    }

    void Update()
    {
        switch (gs)
        {
            case gameState.playing:
                pauseObjects.SetActive(false);
                playingObjects.SetActive(true);
                Time.timeScale = 1;

                if (Input.GetKeyDown("p"))
                {
                    gs = gameState.paused;
                }

                else if (playerHealth.playerHealth == 0)
                {
                    gs = gameState.gameover;
                }

                else if (playerTf.position.y <= -20)
                {
                    gs = gameState.gameover;
                }

                switch (ws)
                {
                    case weaponSwitchingState.shotgun:
                        shotgun.SetActive(true);
                        uzi.SetActive(false);

                        if (Input.GetKeyDown("r"))
                        {
                            ws = weaponSwitchingState.uzi;
                        }

                        break;

                    case weaponSwitchingState.uzi:
                        shotgun.SetActive(false);
                        uzi.SetActive(true);

                        if (Input.GetKeyDown("r"))
                        {
                            ws = weaponSwitchingState.shotgun;
                        }

                        break;
                }

                break;

            case gameState.paused:
                pauseObjects.SetActive(true);
                playingObjects.SetActive(false);
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

            case gameState.gameover:
                gameOverObjects.SetActive(true);
                playingObjects.SetActive(false);
                Time.timeScale = 0;

                if (Input.GetKeyDown("r"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                break;
        }

        healthDisplay.text = "Health: " + playerHealth.playerHealth;
        ammoDisplayShotgun.text = "Shotgun ammo: " + ammoShotgun.Ammo;
        ammoDisplayUzi.text = "Uzi ammo: " + ammoUzi.Ammo;
    }

    void CheckIfDead()
    {
        if (textdingetje == true && playerHealth.playerHealth == 0)
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
