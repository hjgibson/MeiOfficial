using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

/*
 * Author : Gibson, Hannah
 * Last Modified : 5/6/2024
 *Controllers the player movement, player can also throw ultimate 
 */
public class Player : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject objectToThrow;

    public int totalThrows;
    public float throwCooldown;

    public float throwForce =10f;
    public float upwardForce = 10f;

    private bool readyToThrow;

    private PlayerActionMap playerActionMap;

    private float speed = 4f;

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
    private void Awake()
    {
        playerActionMap = new PlayerActionMap();
        playerActionMap.Enable();
    }

    private void FixedUpdate()
    {
        Vector2 moveVector = playerActionMap.Movement.Move.ReadValue<Vector2>();
        GetComponent<Rigidbody>().AddForce( new Vector3(moveVector.x, 0, moveVector.y) * speed * Time.deltaTime, ForceMode.Impulse);
    }
    /// <summary>
    /// player instantiates a prefab and throws it forward, added a throw count so that players starts off with only one ult
    /// </summary>
    private void ThrowUlt()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow,transform.position, Quaternion.identity);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = transform.forward * throwForce +transform.up * upwardForce ;

        rb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;


    }

  
}