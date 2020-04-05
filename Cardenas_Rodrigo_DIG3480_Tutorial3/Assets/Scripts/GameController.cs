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

private bool gameOver;
private bool winGame;
private bool restart;
private int score;

void Start()
{
gameOver = false;
winGame = false;
restart = false;
restartText.text = "";
gameOverText.text = "";
winText.text = "";
score = 0;
UpdateScore();
StartCoroutine(SpawnWaves());
}

void Update ()
{
    if (restart)
    {
        if (Input.GetKeyDown (KeyCode.Q))
        {
            SceneManager.LoadScene("Main");
        }
    }

    if (Input.GetKey("escape"))
    {
        Application.Quit();
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
            restartText.text = "Press 'Q' for Restart";
            restart = true;
            break;
        }
    }
}

public void AddScore(int newScoreValue)
{
    score += newScoreValue;
    UpdateScore();
    if (score >= 100)
    {
        winText.text = "You win! Game created by Rodrigo Cardenas";
        winGame = true;
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
        gameOverText.text = "Game Over! Game created by Rodrigo Cardenas.";
        gameOver = true;
    }
}

}