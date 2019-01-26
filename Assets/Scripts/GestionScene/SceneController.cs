using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string nextSceneName;

    public static SceneController instance;

    private string menuSceneName = "GIVE ME A REAL NAME"; //TODO 

    

    void Start()
    {
        instance = this;
    }

    public void GoToMenu()
    {
        Debug.Log("Mauvaise valeur de variable car la scene n'a pas été définie");
        // SceneManager.LoadScene(SceneManager.GetSceneByName(menuSceneName).buildIndex);
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName(nextSceneName).buildIndex);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


