using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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

    public int totalThrows = 2;
    public float throwCooldown;

    public float throwForce =10f;
    public float upwardForce = 10f;

    private bool readyToThrow;

    private PlayerActionMap playerActionMap;

    public float speed = 4f;

    private Rigidbody rb;

    private Vector3 moveDirection;

    public Transform orientation;

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToThrow = true;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Q) && readyToThrow && totalThrows > 0)
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
        moveDirection = orientation.forward + orientation.right;
        Vector2 moveVector = playerActionMap.Movement.Move.ReadValue<Vector2>();
        rb.transform.Translate(new Vector3(moveVector.x, 0f, moveVector.y) * speed * Time.deltaTime);
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