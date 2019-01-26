using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public string InteractAxeName;

    public bool isHoldingObject = false;

    private GameObject target = null;

    // List of interactable objects (their controller scripts)
    private TapisController pickedUpTapis = null;
    

    private bool hasRetrievedToy;

    private void Update()
    {
        if (Input.GetButtonDown(InteractAxeName))
        {
            if (target != null && !isHoldingObject)
            {
                InteractWithTarget();
            }
            else if (isHoldingObject)
            {
                TryToDrop();
            }
        }
    }

    #region COLLIDERS

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (target == null) // Cause possible de bug // TODO le check
        {
            target = col.gameObject;
        }
    }

    // Prevent trigger after leaving trigger zone
    private void OnTriggerExit2D(Collider2D col)
    {
        if(target == col.gameObject)
        {
            target = null;
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
        if (tapis != null)
        {
            tapis.PickUp(this.gameObject);
            isHoldingObject = true;
            pickedUpTapis = tapis;
        }

        if (target.tag == "Toy"){
            hasRetrievedToy = true;
            Destroy(target);
        }
    }

    private void TryToDrop()
    {
        if (pickedUpTapis != null)
        {
            if (pickedUpTapis.CanPutDown(this.gameObject.transform.position, GetDirection()))
            {
                pickedUpTapis.PutDown(this.gameObject.transform.position, GetDirection());
                isHoldingObject = false;
                pickedUpTapis = null;
            } else
            {
                FailToDrop();
            }
        }
    }

    public void FailToDrop()
    {
        Debug.Log("failToDrop");
        // Play interdiction sound
    }

    private Vector3 GetDirection()
    {
        switch (GetComponent<PlayerMovement>().GetDirection())
        {
            case "up":
                return Vector2.up;
            case "down":
                return Vector2.down;
            case "left":
                return Vector2.left;
            default: // default right
                return Vector2.right;
        }
    }
    #endregion

}
