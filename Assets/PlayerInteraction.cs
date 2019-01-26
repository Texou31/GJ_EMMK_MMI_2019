using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public string InteractAxeName;

    private GameObject target;

    private void Update()
    {
        if (Input.GetButtonDown(InteractAxeName))
        {
            if(target != null)
            {
                InteractWithTarget();
            }
        }
    }


    #region COLLIDERS

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (target != col.gameObject && target != null)
        {
            Deselect();
        }

        target = col.gameObject;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == target)
        {
            Deselect();
        }
    }

    #endregion

    #region INTERACTIONS
    private void InteractWithTarget()
    {
        /*
         * Interact with the target object. Get component to know what to do.
         */
        TapisController tapis = target.GetComponent<TapisController>();
        if (tapis != null) { 

            //Debug.Log("Interact with tapis");
            tapis.Interact(this.gameObject);

            /*
             * Soucis actuel : on arrive pas à prendre le tapis car il est reposé de suite...
             */ 
        }
    }

    void Deselect()
    {
        target = null;
        //Debug.Log("Deselection !");
    }

    #endregion

}
