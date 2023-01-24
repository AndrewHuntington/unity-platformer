using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
  [SerializeField] int playerLives = 3;
  [SerializeField] int playerScore = 0;
  [SerializeField] TextMeshProUGUI livesText;
  [SerializeField] public TextMeshProUGUI scoreText;


  void Awake()
  {
    int numGameSessions = FindObjectsOfType<GameSession>().Length;
    if (numGameSessions > 1)
    {
      Destroy(gameObject);
    }
    else
    {
      DontDestroyOnLoad(gameObject);
    }
  }

  void Start()
  {
    livesText.text = playerLives.ToString();
    scoreText.text = playerScore.ToString();
  }

  public void AddToScore(int pointsToAdd)
  {
    playerScore += pointsToAdd;
    scoreText.text = playerScore.ToString();
  }

  public void ProcessPlayerDeath()
  {
    if (playerLives > 1)
    {
      Invoke("TakeLife", 1f);
    }
    else
    {
      Invoke("ResetGameSession", 1f);
    }
  }

  void TakeLife()
  {
    playerLives--;
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
    livesText.text = playerLives.ToString();
  }

  void ResetGameSession()
  {
    FindObjectOfType<ScenePersist>().ResetScenePersist();
    SceneManager.LoadScene(0);
    Destroy(gameObject);
  }
}
