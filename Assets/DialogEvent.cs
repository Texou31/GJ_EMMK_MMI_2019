using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEvent : MonoBehaviour
{
    public DialogManager dialogManager;

    private Dialog dialog;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        dialog = GetComponent<Dialog>();
        col = GetComponent<BoxCollider2D>();
    }

    public void EndDialog()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            dialogManager.SetDialog(dialog.GetDialog(), this.gameObject);
            col.enabled = false;
        }
    }
}
