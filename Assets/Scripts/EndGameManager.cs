﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public GameObject victoryTab;
    public GameObject gameOverTab;

    public bool canCallByKeyDown;

    private PauseManager pauseManager;

    private void Start()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    private void Update()
    {
        if (canCallByKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                Victory();
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                GameOver();
            }
        }
    }

    public void OnClickMenu()
    {
        Debug.Log("Menu !");
        //SoundController.instance.PlayFX(FX.Click);
        SceneController.instance.GoToMenu();
    }

    public void OnClickNext()
    {
        Debug.Log("Next scene !");
        //SoundController.instance.PlayFX(FX.Click);
        SceneController.instance.GoToNextLevel();
    }

    public void OnClickReload()
    {
        Debug.Log("Restart !");
        //SoundController.instance.PlayFX(FX.Click);
        SceneController.instance.Reload();
    }

    public void Victory()
    {
        //SoundController.instance.PlayFX(FX.Victory);
        pauseManager.canBePaused = false;
        victoryTab.SetActive(true);
        pauseManager.PauseGameplay();
    }

    public void GameOver()
    {
        //SoundController.instance.PlayFX(FX.GameOver);
        pauseManager.canBePaused = false;
        gameOverTab.SetActive(true);
        pauseManager.PauseGameplay();
    }
}
