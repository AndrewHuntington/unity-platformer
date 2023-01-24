using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
  [SerializeField] float levelLoadDelay = 1f;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      StartCoroutine(LoadNextLevel());
    }
  }

  IEnumerator LoadNextLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;

    if (nextSceneIndex != SceneManager.sceneCountInBuildSettings)
    {
      yield return new WaitForSecondsRealtime(levelLoadDelay);
      FindObjectOfType<ScenePersist>().ResetScenePersist();
      SceneManager.LoadScene(nextSceneIndex);
    }
    else
    {
      yield return new WaitForSecondsRealtime(0.075f);
      SceneManager.LoadScene(0);

    }
  }
}
