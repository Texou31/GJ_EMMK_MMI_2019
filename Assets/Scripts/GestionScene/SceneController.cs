using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string nextSceneName;

    public static SceneController instance;

    private string menuSceneName = "MenuScene";  

    void Start()
    {
        instance = this;
        if(nextSceneName == "")
        {
            Debug.Log("Pas de valeur pour nextScene !");
            nextSceneName = SceneManager.GetActiveScene().name;
        }
    }

    public void GoToMenu()
    {
        Debug.Log("Valeur définie pour le menu : " + menuSceneName);
        SceneManager.LoadScene(menuSceneName);
    }

    public void GoToNextLevel()
    {
        Debug.Log("Next level call !");
        SceneManager.LoadScene(nextSceneName);
    }

    public void Reload()
    {
        Debug.Log("Reload call !");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


