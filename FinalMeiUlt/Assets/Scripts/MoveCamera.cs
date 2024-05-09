using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author : Gibson, Hannah
 * Last Modified : 5/8/24
 * was supposed to make camera turn with rotation of the player, but it did not work
 */
public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
