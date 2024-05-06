using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
