using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersLinkController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public float linkLength = 2;

    private bool areLinked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckLink();
    }

    public bool AreLinked()
    {
        return areLinked;
    }

    private void CheckLink()
    {
        if(Vector3.Magnitude(player1.transform.position - player2.transform.position) < linkLength)
        {
            areLinked = true;
        } else
        {
            areLinked = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (areLinked)
        {
            Gizmos.color = Color.green;
        } else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawLine(player1.transform.position, player2.transform.position);
    }
}
