using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisuelJoystick : MonoBehaviour
{
    [Range(1, 2)]
    public int player;

    void OnDrawGizmos()
    {
        Vector3 target = new Vector3();
        if(player == 1)
        {
            target.x = Input.GetAxis("Horizontal1");
            target.y = Input.GetAxis("Vertical1");
        } else if (player == 2)
        {
            target.x = Input.GetAxis("Horizontal2");
            target.y = Input.GetAxis("Vertical2");
        } else
        {
            Debug.Log("Bug");
        }
        

        if (target != null)
        {
            // Draws a blue line from this transform to the target
            
            if (player == 1)
            {
                Gizmos.color = Color.blue;
            }
            else if(player == 2)
            {
                Gizmos.color = Color.green;
            } else
            {
                Gizmos.color = Color.red;
            }
            Gizmos.DrawLine(transform.position, target + transform.position);
        }
    }
}
