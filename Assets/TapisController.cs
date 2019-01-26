using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapisController : MonoBehaviour
{
    private bool isHeld;
    private GameObject holder;

    private Vector2 rotation = Vector2.zero;
    
    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        isHeld = false;
        holder = null;
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isHeld)
        {
            //
        }
    }

    public void Interact(GameObject newHolder)
    {
        if (!isHeld)
        {
            SetNewHolder(newHolder);
            GetComponent<BoxCollider2D>().enabled = false;
            rend.enabled = false;

            return;
        }
    }

    public void StopInteract()
    {
        if (holder != null)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            rend.enabled = true;
            setPositionOffset();
            UnsetHolder();
        }
    }

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
