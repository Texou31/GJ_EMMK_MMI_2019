using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        tag = "Hole";
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Contains("Carpet")){
            Debug.Log("I am no longer a hole. I can be anything and I want to be Untagged!");
            tag = "Untagged";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag.Contains("Carpet")){
            Debug.Log("You thought I was untagged but it's me, A HOLE!");
            tag = "Hole";
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }        
}
