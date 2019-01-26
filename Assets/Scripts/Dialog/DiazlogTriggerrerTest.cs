using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiazlogTriggerrerTest : MonoBehaviour
{

    public DialogManager dialogManager;

    private Dialog dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = GetComponent<Dialog>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogManager.IsFree())
            {
                dialogManager.SetDialog(dialog.GetDialog(), this.gameObject);
            }
        }
    }
}
