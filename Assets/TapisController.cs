using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapisController : MonoBehaviour
{
    public float length;

    private GameObject holder;

    
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    

    // Start is called before the first frame update
    void Start()
    {
        holder = null;

        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void PickUp(GameObject newHolder)
    {
        Debug.Log("Call pickUp");
        if (holder == null && !newHolder.GetComponent<PlayerInteraction>().isHoldingObject)
        {
            PutToInventory(newHolder);
        }
    }

    public bool CanPutDown(Vector2 playerPosition, Vector2 direction) // direction et position
    {
        Debug.DrawRay(playerPosition, direction * length);
        RaycastHit2D hit = Physics2D.Raycast(playerPosition, direction, length * 1000, LayerMask.GetMask("Obstacle"));
        
        return (hit.collider == null);
    }

    public void PutDown(Vector2 playerPosition, Vector2 direction)
    {
        spriteRenderer.enabled = true;// Le rendre visible
        EnableCollision();// réactiver ses collisions
        holder = null;// Update son holder et isheld
        Snap(playerPosition, direction);
        CoverHoles();
    }

    private void PutToInventory(GameObject newHolder)
    {
        holder = newHolder; // dit qu'il est tenu et par qui
        DisableCollision(); // empecher ses collisions
        spriteRenderer.enabled = false; // le faire disparaitre
        UncoverHoles();
    }

    private void Snap(Vector2 position, Vector2 direction)
    {
        Debug.Log("Snap TODO !");
    }

    private void CoverHoles()
    {
        Debug.Log("CoverHoles TODO !");
    }

    private void UncoverHoles()
    {
        Debug.Log("UncoverHoles TODO !");
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

    /*
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
    */
    #endregion
  
    /*
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
    }*/
}
