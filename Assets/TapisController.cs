using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapisController : MonoBehaviour
{
    private bool isHeld;
    private GameObject holder;

    private Vector2 rotation = Vector2.zero;

    private SpriteRenderer rend;

    public bool isColliding = false; // Is the carpet currently colliding with another object ? Used to trigger TryToDrop() in PlayerInteraction.cs

    // Start is called before the first frame update
    void Start()
    {
        isHeld = false;
        holder = null;
        rend = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        isColliding = false;
    }

    public void Interact(GameObject newHolder)
    {
        if (!isHeld)
        {
            SetNewHolder(newHolder);
            DisableCollision();
            rend.enabled = false;

            return;
        }
    }

    public void StopInteract()
    {
        if (holder != null)
        {
            // Collision was already enabled by PlayerInteraction.cs TryToDrop()
            rend.enabled = true;
            setPositionOffset();
            UnsetHolder();
        }
    }

    #region COLLIDERS

    public void EnableCollision()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DisableCollision()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            isColliding = true;
            Debug.Log("isColliding " + isColliding);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            isColliding = false;
            Debug.Log("isColliding " + isColliding);
        }
    }

    #endregion

    private void SetNewHolder(GameObject newHolder)
    {
        isHeld = true;
        holder = newHolder;

        transform.SetParent(holder.transform);
    }

    private void UnsetHolder()
    {
        isHeld = false;
        holder = null;

        transform.SetParent(null);
    }

    private void setPositionOffset()
    {
        PlayerMovement holderMovement = holder.GetComponent<PlayerMovement>();
        switch (holderMovement.getDirection())
        {
            case "up":
                transform.eulerAngles = new Vector3(0, 0, 90);
                transform.localPosition = new Vector3(0, 1.5f, 0);
                break;
            case "down":
                transform.eulerAngles = new Vector3(0, 0, 90);
                transform.localPosition = new Vector3(0, -1.5f, 0);
                break;
            case "right":
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.localPosition = new Vector3(1.5f, 0, 0);
                break;
            default: // left
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.localPosition = new Vector3(-1.5f, 0, 0);
                break;
        }
    }
}
