using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

  public Text pointsText;
  public Text restartText;
  public Text gameOverText;
  public Text winText;

  private bool gameOver;
  private bool restart;
  public static int points;

  public AudioSource musicSource;
  public AudioClip musicClipOne;
  public AudioClip musicClipTwo;

  int WaveCounter = 1;
  int HazardCountIncrease = 1;
  float SpawnSpeedIncrease = 0.2f;

  void Start ()
  {
    gameOver = false;
    restart = false;
    restartText.text = "";
    gameOverText.text = "";
    winText.text = "";
    points = 0;
    UpdatePoints();
    StartCoroutine (SpawnWaves ());
  }

  void Update ()
  {
    if (restart)
    {
        if (Input.GetKeyDown (KeyCode.Q))
        {
          SceneManager.LoadScene("SampleScene");
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
      hazardCount += (WaveCounter * HazardCountIncrease);
      for (int i = 0; i < hazardCount; i++)
      {
        GameObject hazard = hazards [Random.Range (0, hazards.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(hazard, spawnPosition, spawnRotation);
        yield return new WaitForSeconds(spawnWait - (WaveCounter * SpawnSpeedIncrease));
      }
    yield return new WaitForSeconds(waveWait);
    WaveCounter++;

    if (gameOver)
    {
      restartText.text = "Press 'Q' for Restart";
      restart = true;
      break;
    }
    }
}

  public void AddScore(int newPointsValue)
  {
    points += newPointsValue;
    UpdatePoints();
  }

  void UpdatePoints()
  {
    pointsText.text = "Points: " + points;
    if (points >= 100)
    {
      winText.text = "You win! Game created by Sebastian Ortega";
      gameOver = true;
      restart = true;
      musicSource.clip = musicClipOne;
      musicSource.Play();
    }
  }

  public void GameOver ()
  {
      gameOverText.text = "Game Over!";
      gameOver = true;
      musicSource.clip = musicClipTwo;
      musicSource.Play();
  }
}