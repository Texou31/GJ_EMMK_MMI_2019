using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
    private bool isCovered;

    // Start is called before the first frame update
    void Start()
    {
        isCovered = false;
        tag = "Hole";
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Carpet")){
            this.isCovered = true;
            tag = "Floor";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Carpet")){
            this.isCovered = false;
            tag = "Hole";
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }        
}
