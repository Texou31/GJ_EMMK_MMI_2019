using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public string InteractAxeName;

    public bool isHoldingObject = false;
    private GameObject target = null;

    private TapisController pickedUpTapis;

    private bool hasRetrievedToy; // Use to check on exit if victory

    // List of interactable objects (their controller scripts)
    private List<string> interactableObjectsTags;
    private string currentInteractableObject;

    public PlayerInteraction(){
        interactableObjectsTags = new List<string>();
        interactableObjectsTags.Add("Carpet");
        interactableObjectsTags.Add("Exit");
        interactableObjectsTags.Add("Toy");

        pickedUpTapis = null;
    }
    
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
        if (target == null && interactableObjectsTags.Contains(col.gameObject.tag)) // Cause possible de bug // TODO le check
            {
                target = col.gameObject;
                currentInteractableObject = col.gameObject.tag;
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
        Debug.Log("Interact with target" + target.name);

        /*
         * Interact with the target object. Get component to know what to do.
         */
        if(currentInteractableObject.Equals("Exit")){
            /*
            * Interacting with the exit, leaving the level
            */
            if (hasRetrievedToy)
            {
                Debug.Log("Par ici la sortie !");
                //EndGameManager.Victory(); // Replace SceneManager
                SceneManager.LoadScene(SceneController.instance.nextSceneName);
            }
        }
        
         if(currentInteractableObject.Equals("Carpet")){
            TapisController tapis = target.GetComponent<TapisController>();
            Debug.Log("Je prends un tapis !");
            tapis.PickUp(this.gameObject);
            isHoldingObject = true;
            pickedUpTapis = tapis;
        }

        if (currentInteractableObject.Equals("Toy"))
        {
            Debug.Log("On récupère le jouet");
            hasRetrievedToy = true;
            Destroy(target);
        }
    }

    private void TryToDrop()
    {
        if (pickedUpTapis != null)
        {
            Debug.Log("J'ai bien un tapis à poser !");
            if (pickedUpTapis.CanPutDown(this.gameObject.transform.position, GetDirection()))
            {
                Debug.Log("J'ai bien la place de le poser !!");
                pickedUpTapis.PutDown(this.gameObject.transform.position, GetDirection());
                isHoldingObject = false;
                pickedUpTapis = null;
                target = null;
                Debug.Log("Posons le tapis.");
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

    private Vector2 GetDirection()
    {
        Debug.Log("GetDirection direction = " + GetComponentInChildren<PlayerMovement>().GetDirection());

        switch (GetComponentInChildren<PlayerMovement>().GetDirection())
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
