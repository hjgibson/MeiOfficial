using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// gibson, hannah
/// </summary>
public class Player : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject objectToThrow;

    public int totalThrows;
    public float throwCooldown;

    public float throwForce =10f;
    public float upwardForce = 10f;

    private bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && readyToThrow && totalThrows > 0)
        {
            ThrowUlt();
        }
    }

    private void ThrowUlt()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow,transform.position, Quaternion.identity);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = transform.forward * throwForce +transform.up * upwardForce ;

        ///force is added continuosly, need to take away so ball stays where it lands
        rb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;


    }

  
}