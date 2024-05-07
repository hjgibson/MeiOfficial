using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author : Gibson, Hannah
 * Last Modified : 5/6/2024
 * controls the motion of the ultimate being thrown and sticking to the place it lands
 */
public class ProjectileStick : MonoBehaviour
{
    private Rigidbody rb;

    private bool groundHit;

    public float releaseForce = 10f;

    public float radius = 10f;

    public float upwardsForce = 1f;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// when the ult prefab collides with the ground, the ultimate is released
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Plane")
        {
           

            if (groundHit)
            {
                return;
            }
            else
            {
                groundHit = true;
            }

            rb.isKinematic = true;

            ReleaseUlt();

        }
    }
    /// <summary>
    /// creates a bigger sphere collider in which anything inside gets affected by the ult
    /// </summary>
    private void ReleaseUlt()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider near in colliders)
        {
            if (near.CompareTag("Enemy"))
            {
                Debug.Log("hit enemy");
                Enemy health = near.GetComponent<Enemy>();
                if(health != null)
                {
                    health.TakeDamage();
                }
            }
            Rigidbody rgb = near.GetComponent<Rigidbody>();

            
        }
       
    }
    /// <summary>
    /// helps to see the AoE collider sphere
    /// </summary>
    void OnDrawGizmosSelected()
    {
       
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

        
    }
}
