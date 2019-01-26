/* Author : Raphaël Marczak - 2018, for ENSEIRB-MATMECA
 * 
 * This work is licensed under the CC0 License. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is used to correctly display a full dialog
public class DialogManager : MonoBehaviour {

    public Text m_renderText;
    public string nextButtonAxe;

    public GameObject player1;
    public GameObject player2;

    private List<DialogPage> m_dialogToDisplay;
    private GameObject lastEmitter;

	// Update is called once per frame
	void Update () {

        // Displays the current page
		if (m_dialogToDisplay.Count > 0)
        {
            m_renderText.text = m_dialogToDisplay[0].text;
        } else
        {
            EndDialog();
        }

        // Remoeves the page when the player presses the submit axe
        if (Input.GetButtonDown(nextButtonAxe))
        {
            m_dialogToDisplay.RemoveAt(0);
        }
	}

    // Sets the dialog to be displayed
    public void SetDialog(List<DialogPage> dialogToAdd, GameObject emitter)
    {
        m_dialogToDisplay = new List<DialogPage>(dialogToAdd);
        lastEmitter = emitter;

        if (m_dialogToDisplay.Count > 0)
        {
            if (m_renderText != null)
            {
                m_renderText.text = "";
            }
            DisableControllers();
            this.gameObject.SetActive(true);
        }
    }

    public bool IsOnScreen()
    {
        return this.gameObject.activeSelf;
    }

    public bool IsFree()
    {
        return !this.gameObject.activeSelf;
    }

    private void EnableControllers()
    {
        player1.GetComponent<PlayerMovement>().enabled = true;
        player1.GetComponent<PlayerInteraction>().enabled = true;
        player2.GetComponent<PlayerMovement>().enabled = true;
        player2.GetComponent<PlayerInteraction>().enabled = true;
    }

    private void DisableControllers()
    {
        player1.GetComponent<PlayerMovement>().enabled = false;
        player1.GetComponent<PlayerInteraction>().enabled = false;
        player2.GetComponent<PlayerMovement>().enabled = false;
        player2.GetComponent<PlayerInteraction>().enabled = false;
    }

    private void EndDialog()
    {
        DialogEvent dialogEvent = lastEmitter.GetComponent<DialogEvent>();
        if(dialogEvent != null)
        {
            dialogEvent.EndDialog();
        }
        EnableControllers();
        lastEmitter = null;
        this.gameObject.SetActive(false);
    }
}
