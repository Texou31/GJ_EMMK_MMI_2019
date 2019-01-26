using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterDoor : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D door;

    public Sprite P1Door;
    public Sprite P2Door;

    public string targetTag;

    // Start is called before the first frame update
    void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D> ();

        foreach (var collider in colliders) {
            if (!collider.isTrigger){
                door = collider;
            }
        }

        if (targetTag == "Player 1") {
            spriteRenderer.sprite = P1Door;
        }

        if (targetTag == "Player 2") {
            spriteRenderer.sprite = P2Door;
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == targetTag) {
            UnityEngine.Debug.Log ("WOOOAG LIVING ");

            door.enabled = false;
            spriteRenderer.enabled = false;
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag == targetTag) {
            UnityEngine.Debug.Log ("ON A PRAYER!");
            door.enabled = true;
            spriteRenderer.enabled = true;
        }
    }
}