/* Author : Raphaël Marczak - 2018, for ENSEIRB-MATMECA
 * 
 * This work is licensed under the CC0 License. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour {
    public GameObject m_object1ToFollow;
    public GameObject m_object2ToFollow;
	
	// At each frame, the camera position is set to the "objetToFollow" x and y coordinates
    // (z remains the one of the camera, to respect the depth)
	void LateUpdate () {
        Vector2 v1 = new Vector2(m_object1ToFollow.transform.position.x,
                                 m_object1ToFollow.transform.position.y);
        Vector2 v2 = new Vector2(m_object2ToFollow.transform.position.x,
                                 m_object2ToFollow.transform.position.y);
        Vector3 newPosition = new Vector3((v1.x + v2.x) / 2,
                                               (v1.y + v2.y) / 2,
                                               transform.position.z);
        this.transform.position = newPosition;
	}
}
