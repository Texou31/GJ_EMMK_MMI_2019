using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public string InteractAxeName;

    private GameObject target;
    private bool isSelected = false;

    // List of interactable objects (their controller scripts)
    private TapisController tapis;

    private bool hasRetrievedToy;

    private void Update()
    {
        if (Input.GetButtonDown(InteractAxeName))
        {
            if (target != null && !isSelected)
            {
                InteractWithTarget();
            }
            else
            {
                Deselect();
            }
        }
    }


    #region COLLIDERS

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (target == null)
        {
            target = col.gameObject;
        }
    }

    // Prevent trigger after leaving trigger zone
    private void OnTriggerExit2D(Collider2D col)
    {
        target = null;
    }

    #endregion

    #region INTERACTIONS
    private void InteractWithTarget()
    {
        /*
         * Interact with the target object. Get component to know what to do.
         */
        tapis = target.GetComponent<TapisController>();
        if (tapis != null)
        {
            //Debug.Log("Interact with tapis");
            tapis.Interact(this.gameObject);
            isSelected = true;
        }

        if (target.tag == "Toy"){
            hasRetrievedToy = true;
            Destroy(target);
        }
    }

    void Deselect()
    {
        tapis.StopInteract();
        target = null;
        AllScriptsToNull();
        isSelected = false;
        //Debug.Log("Deselection !");
    }

    private void AllScriptsToNull()
    {
        tapis = null;
    }

    #endregion

}
