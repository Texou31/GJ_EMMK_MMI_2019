using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 2f;

    public BoxCollider2D rightCol;
    public BoxCollider2D leftCol;
    public BoxCollider2D upCol;
    public BoxCollider2D downCol;

    public CircleCollider2D feet;

    public string horizontalAxis;
    public string verticalAxis;

    public Sprite Face;
    public Sprite Back;
    public Sprite Left;

    private Vector2 movement = Vector2.zero;
    private Vector2 lastMovement = Vector2.zero;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;

    public string direction;

    private bool isSliding = false;

    private void Start () {
        rb = GetComponentInParent<Rigidbody2D> ();
        sr = GetComponentInParent<SpriteRenderer> ();
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (!isSliding) {
            movement.x = Input.GetAxisRaw (horizontalAxis);
            movement.y = Input.GetAxisRaw (verticalAxis);
        }
    }

    private void FixedUpdate () {
        Move ();
    }

    public string GetDirection()
    {
        return direction;
    }

    #region PRIVATE FUNCTIONS
    private void Move () {
        rb.MovePosition (rb.position + movement * moveSpeed * Time.deltaTime);
        UpdateColliders ();
        UpdateSprites ();
    }

    private void UpdateColliders () {
        if (movement.y > 0.1f) // Up enabled
        {
            direction = "up";
            upCol.enabled = true;
            downCol.enabled = false;
            rightCol.enabled = false;
            leftCol.enabled = false;
        } else if (movement.y < -0.1f) // Down enabled
        {
            direction = "down";
            upCol.enabled = false;
            downCol.enabled = true;
            rightCol.enabled = false;
            leftCol.enabled = false;
        }

        if (movement.x > 0.1f) // Right enabled
        {
            direction = "right";
            upCol.enabled = false;
            downCol.enabled = false;
            rightCol.enabled = true;
            leftCol.enabled = false;
        } else if (movement.x < -0.1f) // Left enabled
        {
            direction = "left";
            upCol.enabled = false;
            downCol.enabled = false;
            rightCol.enabled = false;
            leftCol.enabled = true;
        }
    }

    private void UpdateSprites()
    {
        if(movement.magnitude > 0.2)
        {
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0.1)
                {
                    animator.SetTrigger("GoRight");
                }
                else if (movement.x < 0.1)
                {
                    animator.SetTrigger("GoLeft");
                }
            }
            else
            {
                if (movement.y > 0.1)
                {
                    animator.SetTrigger("GoUp");
                }
                else if (movement.y < 0.1)
                {
                    animator.SetTrigger("GoDown");
                }
            }
        }

        animator.SetFloat("Speed", movement.magnitude / moveSpeed);
      }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Ice") {
            isSliding = true;
        }

        if (other.gameObject.tag == "Hole"){
            Debug.Log("GAME OVER!!!");
        }

        if (other.gameObject.tag == "Carpet"){
            other.gameObject.tag = "BlockedCarpet";
        }
    }

      private void OnTriggerExit2D (Collider2D other) {
          if (other.gameObject.tag == "Ice") {
              isSliding = false;
          }

          if (other.gameObject.tag == "BlockedCarpet"){
              other.gameObject.tag = "Carpet";
          }
        }

    #endregion

}
