using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    public BoxCollider2D rightCol;
    public BoxCollider2D leftCol;
    public BoxCollider2D upCol;
    public BoxCollider2D downCol;

    public string horizontalAxis;
    public string verticalAxis;

    public Sprite Face;
    public Sprite Back;
    public Sprite Left;

    private Vector2 movement = Vector2.zero;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        sr = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw(horizontalAxis);
        movement.y = Input.GetAxisRaw(verticalAxis);
    }

    private void FixedUpdate()
    {
        Move();
    }

    #region PRIVATE FUNCTIONS
    private void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        UpdateColliders();
        UpdateSprites();
    }

    private void UpdateColliders()
    {
        if (movement.y > 0.1f)  // Up enabled
        {
            upCol.enabled = true;
            downCol.enabled = false;
            rightCol.enabled = false;
            leftCol.enabled = false;
        }
        else if (movement.y < -0.1f) // Down enabled
        {
            upCol.enabled = false;
            downCol.enabled = true;
            rightCol.enabled = false;
            leftCol.enabled = false;
        }

        if (movement.x > 0.1f)  // Right enabled
        {
            upCol.enabled = false;
            downCol.enabled = false;
            rightCol.enabled = true;
            leftCol.enabled = false;
        }
        else if (movement.x < -0.1f)    // Left enabled
        {
            upCol.enabled = false;
            downCol.enabled = false;
            rightCol.enabled = false;
            leftCol.enabled = true;
        }
    }

    private void UpdateSprites()
    {
        if (movement.y > 0.1f)  // Up enabled
        {
            sr.sprite = Back;
            sr.flipX = false;
        }
        else if (movement.y < -0.1f) // Down enabled
        {
            sr.sprite = Face;
            sr.flipX = false;
        }

        if (movement.x > 0.1f)  // Right enabled
        {
            sr.sprite = Left;
            sr.flipX = true;
        }
        else if (movement.x < -0.1f)    // Left enabled
        {
            sr.sprite = Left;
            sr.flipX = false;
        }
    }

    #endregion

}
