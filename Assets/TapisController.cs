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

        tag = "Carpet";
    }

    public void PickUp(GameObject newHolder)
    {
        if (holder == null && !newHolder.GetComponent<PlayerInteraction>().isHoldingObject)
        {
            tag = "Untagged";
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
        Debug.Log("Moi, le tapis, je vais être posé !");
        tag = "Carpet";
        spriteRenderer.enabled = true;// Le rendre visible
        EnableCollision();// réactiver ses collisions
        holder = null;// Update son holder et isheld
        Snap(playerPosition, direction);
    }

    private void PutToInventory(GameObject newHolder)
    {
        holder = newHolder; // dit qu'il est tenu et par qui
        DisableCollision(); // empecher ses collisions
        spriteRenderer.enabled = false; // le faire disparaitre
    }

    private void Snap(Vector2 position, Vector2 direction)
    {
        //Debug.Log("position pre-snap : X = " + position.x.ToString() + " / Y = " + position.y.ToString());
        position = new Vector2(Mathf.Round(position.x - 0.5f) + 0.5f, Mathf.Round(position.y - 0.5f) + 0.5f);
        //Debug.Log("position post-snap : X = " + position.x.ToString() + " / Y = " + position.y.ToString());
       

        if (direction == Vector2.right)
        {
            transform.position = new Vector2(position.x + length / 2f + 0.5f, position.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if(direction == Vector2.left)
        {
            transform.position = new Vector2(position.x - length / 2f - 0.5f, position.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if (direction == Vector2.up)
        {
            transform.position = new Vector2(position.x, position.y + length / 2f + 0.5f);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        } else if (direction == Vector2.down)
        {
            transform.position = new Vector2(position.x, position.y - length / 2f - 0.5f);
            transform.rotation = Quaternion.Euler(0, 0, 90);
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
}
