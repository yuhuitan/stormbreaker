using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{

    public static int lives = 3;
    public GameObject spawnPoint;
    public static int enemyAlive = 1;
    public GameObject[] portals;
    public GameObject[] bosses;
    public GameObject bossSpawnPoint;
    public AudioSource backgroundMusic;
    public AudioSource bossMusic;
    public AudioSource levelPassMusic;
    public AudioSource victoryMusic;
    public AudioSource gameOverMusic;
    public GameObject[] hearts;



    private GameObject[] gameManagers;
    private Transform originalPositions;
    private GameObject[] players;
    private Player[] playersScripts;
    private GameObject boss;
    private bool lastRespawn = false;
    private bool playerStillActive = false;
    private float targetTime = 10.0f;
    private static float currentTime = 0.0f;
    private int lastChance = 0;
    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndWait;
    public static int currentLevel = 1;
    private bool winLevel = false;
    private static bool bossSummon = false;
    private AudioSource[] clips;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("SIENZZ");
        m_StartWait = new WaitForSeconds(1f);
        m_EndWait = new WaitForSeconds(0.5f);
        // Dont destroy game manager
        gameManagers = GameObject.FindGameObjectsWithTag("GameController");
        if (gameManagers.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        // Dont destroy the players
        Debug.Log("LOL");
        players = GameObject.FindGameObjectsWithTag("Player");
        playersScripts = new Player[players.Length];
        originalPositions = players[0].transform;

        if (players.Length > 2)
        {
            for (int i = 0; i < players.Length - 1; i++)
            {
                Destroy(players[i].gameObject);
            }
        }
        for (int i = 0; i < players.Length; i++)
        {
            playersScripts[i] = players[i].GetComponent<Player>();
            DontDestroyOnLoad(players[i].gameObject);
        }
        
        for (int i =0; i < hearts.Length; i++)
        {
            DontDestroyOnLoad(hearts[i].gameObject);
        }
        originalPositions = spawnPoint.transform;

        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {

        if (bossMusic.isPlaying)
        {
            bossMusic.Stop();
        }

        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }

        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());


        if (winLevel)
        {
            if (currentLevel <= 3)
            {
                Debug.Log("hihihihiihi");
                StartCoroutine(GameLoop());
                Debug.Log("Continue to next level");
            }
            else
            {
                StopPlayingAllAudio();
                if (!victoryMusic.isPlaying)
                {
                    victoryMusic.Play();
                }
                Debug.Log("Finish Game");
                SceneManager.LoadScene("WinningScreen");
                yield break;
            }
        }
        else
        {
            StopPlayingAllAudio();
            if (!gameOverMusic.isPlaying)
            {
                gameOverMusic.Play();
            }

            Debug.Log("lost the level");
            SceneManager.LoadScene("GameOverScreen");
            yield break;
        }
        winLevel = false;
    }

    private IEnumerator RoundStarting()
    {
        //initialize all the enemies and boss
        //deactivate the portal
        //reset enemyalive;
       /* Time.timeScale = 0f;
        cutScenes[currentLevel - 1].Play();
        while (cutScenes[currentLevel - 1].isPlaying)
        {
            Time.timeScale = 0f;
            yield return null;
        }

        Time.timeScale = 1f;*/
        yield return m_StartWait;
    }

    private IEnumerator RoundPlaying()
    {
        Debug.Log("Playing");
        Debug.Log("Current enemy alived: " + enemyAlive);
        Debug.Log("Current life left: " + lives);
        // if one player still active
        while (CheckIfPlayerLeft() && enemyAlive > 0 || lives > 0 && enemyAlive > 0)
        {
                Debug.Log("haahahahahhahaha");
                if (enemyAlive == 1 && !bossSummon && SceneManager.GetActiveScene().name == "Level"+currentLevel)
                {
                    StopPlayingAllAudio();
                    if (!bossMusic.isPlaying)
                    {
                        bossMusic.Play();
                    }
                    Instantiate(bosses[currentLevel - 1], bossSpawnPoint.transform.position, bossSpawnPoint.transform.rotation);
                    bossSummon = true;
                }
                for (int i = 0; i < players.Length; i++)
                {
                    // the player who died
                    if (players[i].activeSelf == false)
                    {
                        // check if still got life left
                        if (lives > 0)
                        {
                            Debug.Log("Player respawn!");
                            playersScripts[i].ResetPlayer(originalPositions);
                            lives -= 1;
                            Destroy(hearts[lives]);
                            Debug.Log("Current Life: " + lives);
                        }
                        else if (lives <= 0 && lastChance == 0)
                        {
                            Debug.Log("Last chance");
                            lastChance = 1;
                        }
                        // when lastChance = 1, it will go to here
                        else
                        {   // check if count down of 10 seconds reached, if reach, then respawn the player
                            Debug.Log("Checking count down");
                            Debug.Log("Current time: " + currentTime);
                            if (currentTime >= targetTime)
                            {
                                playersScripts[i].ResetPlayer(originalPositions);
                                lastChance = 2;
                                currentTime = 0.0f;
                            }
                        }
                        if (lastChance == 1)
                        {
                            CountDown();
                        }
                    }
                }
                // reset the player still active;
                playerStillActive = false;
                yield return null;
        }
    }

    private IEnumerator RoundEnding()
    {
        Debug.Log("Enemy Alive: "+enemyAlive);
        if (!CheckIfPlayerLeft())
        {
            Debug.Log("All Players Death!Game Over!");
            winLevel = false;
        }
        if (enemyAlive == 0)
        {

            Debug.Log(currentLevel);
            if (currentLevel < 3)
            {
                StopPlayingAllAudio();
                if (!levelPassMusic.isPlaying)
                {
                    levelPassMusic.Play();
                }
                Instantiate(portals[currentLevel - 1]);
            }
            currentLevel += 1;
            winLevel = true;
            Debug.Log("CONGRATULATION!");
        }
        // need to change, for testing only
        enemyAlive = 1;
        bossSummon = false;
        Debug.Log("Testing enemy alived: " + enemyAlive);
        yield return m_EndWait;
    }


    private void CountDown()
    {
        Debug.Log("Counting");
        currentTime += Time.deltaTime;
    }

    public void LoadScene(string sceneName)
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].transform.position = originalPositions.transform.position;
        }
        SceneManager.LoadScene(sceneName);
    }

    private bool CheckIfPlayerLeft()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].activeSelf == true)
            {
                playerStillActive = true;
                break;
            }
        }
        return playerStillActive;
    }

    private bool CheckIfClearMap()
    {
        return false;
    }

    public static void ResetGame()
    {
        lives = 3;
        currentTime = 0.0f;
        currentLevel = 1;
        bossSummon = false;
    }

    private void StopPlayingAllAudio()
    {
        if (backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
        if (bossMusic.isPlaying)
        {
            bossMusic.Stop();
        }
        if (levelPassMusic.isPlaying)
        {
            levelPassMusic.Stop();
        }
        if (victoryMusic.isPlaying)
        {
            victoryMusic.Stop();
        }
        if (gameOverMusic.isPlaying)
        {
            gameOverMusic.Stop();
        }
    }
}
