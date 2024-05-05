using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeiUlt : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit enemy!");
        }
    }

}
