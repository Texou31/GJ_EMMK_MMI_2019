using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public GameObject victoryTab;
    public GameObject gameOverTab;

    private PauseManager pauseManager;

    private void Start()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Victory();
        } else if (Input.GetKeyDown(KeyCode.G))
        {
            GameOver();
        }
    }

    public void OnClickMenu()
    {
        Debug.Log("Menu !");
        SceneController.instance.GoToMenu();
    }

    public void OnClickNext()
    {
        Debug.Log("Next scene !");
        SceneController.instance.GoToNextLevel();
    }

    public void OnClickReload()
    {
        Debug.Log("Restart !");
        SceneController.instance.Reload();
    }

    public void Victory()
    {
        pauseManager.canBePaused = false;
        victoryTab.SetActive(true);
        pauseManager.PauseGameplay();
    }

    public void GameOver()
    {
        pauseManager.canBePaused = false;
        gameOverTab.SetActive(true);
        pauseManager.PauseGameplay();
    }
}
