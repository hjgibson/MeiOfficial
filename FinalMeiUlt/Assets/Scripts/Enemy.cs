using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10;

    public float dmgAmount;

    public float duration = 1f;

    private void Start()
    {
        
    }

    public void TakeDamage()
    {
        StartCoroutine(DamageOverTime());

    }

    public void Die()
    {
        gameObject.SetActive(false);
    }


    private IEnumerator DamageOverTime()
    {
        float TimePassed = 0f;

        while(TimePassed < duration)
        {
            float dmgPerSecond = 1f; 

            health -= dmgPerSecond;

            if(health<= 0)
            {
                Die();
            }

            yield return null;
        }
    }
}
