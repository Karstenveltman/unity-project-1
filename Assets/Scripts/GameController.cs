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

    public GameObject gameOverObjects;

    public GameObject pauseObjects;

    public GameObject playingObjects;

    public GameObject victoryObjects;

    public GameObject shotgun;

    public GameObject uzi;

    public Text healthDisplay;

    public Text ammoDisplayShotgun;

    public Text ammoDisplayUzi;

    private gameState gs;
    private weaponSwitchingState ws;

    public float fallKill;

    private VictoryTrigger victoryTrigger;

    enum gameState {playing, paused, gameover, victory}

    enum weaponSwitchingState {shotgun, uzi}

    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        ammoShotgun = GameObject.Find("shotgun").GetComponent<ShotgunScript>();
        ammoUzi = GameObject.Find("uzi").GetComponent<UziScript>();
        playerTf = GameObject.Find("Player").GetComponent<Transform>();
        victoryTrigger = GameObject.Find("Victory Detector").GetComponent<VictoryTrigger>();
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

                else if (playerTf.position.y <= -fallKill)
                {
                    gs = gameState.gameover;
                }

                else if (victoryTrigger.VictoryEnter)
                {
                    gs = gameState.victory;
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

            case gameState.victory:
                victoryObjects.SetActive(true);
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
}
