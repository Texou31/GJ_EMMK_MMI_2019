using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseTab;

    public GameObject player1;
    public GameObject player2;

    public bool isPaused;
    public bool inDialog;

    public bool canBePaused = true;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        inDialog = false;
        canBePaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canBePaused)
        {
            if (isPaused)
            {
                Unpause();
            } else
            {
                Pause();
            }
        }
    }

    public void ClickOnMenu()
    {
        Debug.Log("Menu !");
        SceneController.instance.GoToMenu();
    }

    public void ClickOnRestart()
    {
        Debug.Log("Restart !");
        SceneController.instance.Reload();
    }

    public void ClickOnResume()
    {
        Debug.Log("Unpause !");
        Unpause();
    }

    public void Pause()
    {
        isPaused = true;
        pauseTab.SetActive(true);
        PauseGameplay();
    }

    public void Unpause()
    {
        isPaused = false;
        pauseTab.SetActive(false);
        if (!inDialog)
        {
            UnpauseGameplay();
        }
    }

    public void PauseGameplay()
    {
        player1.GetComponent<PlayerInteraction>().enabled = false;
        player1.GetComponentInChildren<PlayerMovement>().enabled = false;
        player2.GetComponent<PlayerInteraction>().enabled = false;
        player2.GetComponentInChildren<PlayerMovement>().enabled = false;
    }

    public void UnpauseGameplay()
    {
        
        player1.GetComponent<PlayerInteraction>().enabled = true;
        player1.GetComponentInChildren<PlayerMovement>().enabled = true;
        player2.GetComponent<PlayerInteraction>().enabled = true;
        player2.GetComponentInChildren<PlayerMovement>().enabled = true;
    }
}
