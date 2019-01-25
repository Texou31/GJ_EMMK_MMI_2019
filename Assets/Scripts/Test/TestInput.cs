using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    public float horizontal1;
    public float vertical1;

    public float horizontal2;
    public float vertical2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal1 = Input.GetAxis("Horizontal1");
        vertical1 = Input.GetAxis("Vertical1");

        horizontal2 = Input.GetAxis("Horizontal2");
        vertical2 = Input.GetAxis("Vertical2");

        if (Input.GetButtonDown("Interact1"))
        {
            Debug.Log("Interact 1");
        }
        if (Input.GetButtonDown("Interact2"))
        {
            Debug.Log("Interact 2");
        }
        if (Input.GetButtonDown("Submit"))
        {
            Debug.Log("Submit");
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Cancel");
        }
        if (Input.GetButtonDown("Pause"))
        {
            Debug.Log("Pause");
        }
    }
}
