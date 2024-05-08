using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
