using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author : Gibson, Hannah
 * Last Modified : 5/7/24
 * controls the enemy movement while inheriting from the Enemy script
 */
public class EnemyMovement : Enemy
{
  

    public Vector3 direction;

    void Update()
    {

        direction = Vector3.forward;

        Vector3 horizontalMovement = direction.normalized * speed * Time.deltaTime;

        transform.Translate(horizontalMovement);
    }
}
