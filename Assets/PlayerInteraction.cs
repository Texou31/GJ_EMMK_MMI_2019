using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public string InteractAxeName;

    private GameObject target;
    private bool isSelected = false;

    private bool isTryToDrop = false;

    // List of interactable objects (their controller scripts)
    private TapisController tapis;

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
                if (tapis != null)
                {
                    isTryToDrop = true;
                    tapis.EnableCollision();
                }
                    //TryToDrop(target);

                }
        }
    }

    private void FixedUpdate()
    {
        if (isTryToDrop)
        {
            TryToDrop(target);
            isTryToDrop = false;
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
            tapis.Interact(this.gameObject);
            isSelected = true;
        }
    }

    private void TryToDrop(GameObject gameObject)
    {
        Debug.Log("tryToDrop");

        if (tapis != null)
        {
            //tapis.EnableCollision();

            Debug.Log("in tryToDrop before if : isColliding " + tapis.isColliding);
            if (!tapis.isColliding)
            {
                Deselect();
            }
            else
            {
                tapis.DisableCollision();
                FailToDrop();
            }
        }
    }

    public void FailToDrop()
    {
        Debug.Log("failToDrop");
        // Play interdiction sound
    }

    private void Deselect()
    {
        // when several objects to interact with
        // try if object is not null before StopInteract
        // and do that for every object
        // OR switch on content of target
        if (tapis != null)
        {
            tapis.StopInteract();
        }

        target = null;
        AllScriptsToNull();
        isSelected = false;
    }

    private void AllScriptsToNull()
    {
        tapis = null;
    }

    #endregion

}
