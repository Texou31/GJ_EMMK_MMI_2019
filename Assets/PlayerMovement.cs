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

    public string direction;

    private bool isSliding = false;

    private void Start () {
        rb = GetComponentInParent<Rigidbody2D> ();
        sr = GetComponentInParent<SpriteRenderer> ();
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
            upCol.enabled = true;
            downCol.enabled = false;
            rightCol.enabled = false;
            leftCol.enabled = false;
        } else if (movement.y < -0.1f) // Down enabled
        {
            upCol.enabled = false;
            downCol.enabled = true;
            rightCol.enabled = false;
            leftCol.enabled = false;
        }

        if (movement.x > 0.1f) // Right enabled
        {
            upCol.enabled = false;
            downCol.enabled = false;
            rightCol.enabled = true;
            leftCol.enabled = false;
        } else if (movement.x < -0.1f) // Left enabled
        {
            upCol.enabled = false;
            downCol.enabled = false;
            rightCol.enabled = false;
            leftCol.enabled = true;
        }
    }

    private void UpdateSprites () {
        if (movement.y > 0.1f) // Up enabled
        {
            sr.sprite = Back;
            sr.flipX = false;

            direction = "up";
        }
        else if (movement.y < -0.1f) // Down enabled
        {
            sr.sprite = Face;
            sr.flipX = false;

            direction = "down";
        }

        if (movement.x > 0.1f) // Right enabled
        {
            sr.sprite = Left;
            sr.flipX = true;

            direction = "right";
        }
        else if (movement.x < -0.1f)    // Left enabled
        {
            sr.sprite = Left;
            sr.flipX = false;

            direction = "left";
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Ice") {
            isSliding = true;
        }

        if (other.gameObject.tag == "Hole"){
            Debug.Log("UN TROU !");
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag == "Ice") {
            isSliding = false;
        }
    }

    #endregion

}