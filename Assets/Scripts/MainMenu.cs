using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevelName;
    public string creditSceneName;

    public void GoToFirstLevel()
    {
        SceneManager.LoadScene(firstLevelName);
    }

    public void GoToCredit()
    {
        SceneManager.LoadScene(creditSceneName);
    }

    public void GoToExit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
