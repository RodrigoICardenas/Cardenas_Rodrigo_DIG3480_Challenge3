using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
public GameObject[] hazards;
public Vector3 spawnValues;
public int hazardCount;
public float spawnWait;
public float startWait;
public float waveWait;

public Text ScoreText;
public Text restartText;
public Text gameOverText;
public Text winText;
public Text HardModeText;
public Text TimeAttackText;
public Text HardModeStartText;
public Text TimeAttackStartText;
public Text CountdownText;
public Text TimeAttackEndText;

public AudioSource musicSource;
public AudioClip musicClipOne;
public AudioClip musicClipTwo;
public AudioClip musicClipThree;
public AudioClip musicClipFour;

public bool gameOver;
public bool winGame;
private bool restart;
public int score;

public bool TimeAttack;

float currentTime = 0f;
float startTime = 30f;

public CameraShaker CameraShaker;

void Start()
{
gameOver = false;
winGame = false;
restart = false;
TimeAttack = false;
restartText.text = "";
gameOverText.text = "";
winText.text = "";
HardModeText.text = "Press 'E' to start Hard Mode";
TimeAttackText.text = "Press 'Q' to start Time Attack";
HardModeStartText.text = "";
TimeAttackStartText.text = "";
TimeAttackEndText.text = "";
CountdownText.text = "";
score = 0;
UpdateScore();
StartCoroutine(SpawnWaves());
currentTime = startTime;
}

void Update ()
{
    if (restart)
    {
        if (Input.GetKeyDown (KeyCode.R))
        {
            SceneManager.LoadScene("Main");
        }
    }

    if (Input.GetKey("escape"))
    {
        Application.Quit();
    }
    
    if (Input.GetKeyDown (KeyCode.Q))
    {
        TimeAttack = true;
        HardModeText.text = "";
        TimeAttackText.text = "";
        TimeAttackStartText.text = "TIME ATTACK STARTED!";
        musicSource.clip = musicClipFour;
        musicSource.Play();
    }

    if (Input.GetKeyDown (KeyCode.E))
    {
        HardModeText.text = "";
        TimeAttackText.text = "";
        HardModeStartText.text = "HARD MODE ACTIVATED!";
    } 

    if (TimeAttack == true)
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            print (currentTime);
            CountdownText.text = currentTime.ToString ("0");
        }
        if(currentTime>=3.5f)
        {
            CountdownText.color = Color.white;
        }
        if(currentTime<10f)
        {
            CountdownText.color = Color.red;
        }
    }
}

IEnumerator SpawnWaves()
{
    yield return new WaitForSeconds(startWait);
    while (true)
    {
        for (int i = 0; i < hazardCount; i++)
        {
            GameObject hazard = hazards[Random.Range (0,hazards.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
        yield return new WaitForSeconds(waveWait);

        if (gameOver || winGame)
        {
            restartText.text = "Press 'R' for Restart";
            restart = true;
            break;
        }
    }
}

public void AddScore(int newScoreValue)
{
    score += newScoreValue;
    UpdateScore();
    if (TimeAttack == false)
    {
        if (score >= 100)
        {
            winText.text = "You win! Game created by Rodrigo Cardenas";
            HardModeText.text = "";
            TimeAttackText.text = "";
            winGame = true;
            musicSource.clip = musicClipTwo;
            musicSource.Play();
        }
    }
}

void UpdateScore()
{
ScoreText.text = "Score: " + score;
}

public void GameOver ()
{
    if (winGame == false)
    {
        if (TimeAttack == false)
        {
        gameOverText.text = "Game Over! Game created by Rodrigo Cardenas.";
        HardModeText.text = "";
        TimeAttackText.text = "";
        gameOver = true;
        CameraShaker.shouldShake = true;
        musicSource.clip = musicClipThree;
        musicSource.Play();
        }
        else
        {
            TimeAttackEndText.text = "You Scored " + score + " points during Time Attack! Game created by Rodrigo Cardenas.";
            gameOver = true;
            CameraShaker.shouldShake = true;
        }
    }
}

}