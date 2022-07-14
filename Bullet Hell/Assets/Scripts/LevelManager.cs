using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    ScoreKeeper sk;
    static string modeLoaded;

    void Awake()
    {
        sk = FindObjectOfType<ScoreKeeper>();
    }
  public void LoadGame()
  {
      modeLoaded = "Level 1";
      SceneManager.LoadScene("LEVEL 1");
       sk.ResetScore();
  }
  public void Boss1()
  {
     SceneManager.LoadScene("Boss 1");
  }
   public void LoadSurvival()
  {
      modeLoaded = "Survival";
      SceneManager.LoadScene("Survival");
       sk.ResetScore();
  }
  public void LoadLastMode()
  {
      SceneManager.LoadScene(modeLoaded);
       sk.ResetScore();
  }
   public void LoadLevelClear()
  {
      SceneManager.LoadScene("LevelClear");
  }
  public void LoadMainMenu()
  {
      SceneManager.LoadScene("MainMenu");
  }
  public void BossWarning()
  {
       StartCoroutine(WaitAndLoad("Boss Warning", sceneLoadDelay));
  }

  public void LoadGameOver()
  {
      StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
  }
  public void QuitGame()
  {
      Debug.Log("Quitting");
      Application.Quit();
  }
  IEnumerator WaitAndLoad(string sceneName, float delay)
    {
       yield return new WaitForSeconds(delay);
       SceneManager.LoadScene(sceneName);
    }
}
