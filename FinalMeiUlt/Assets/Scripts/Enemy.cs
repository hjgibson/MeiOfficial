using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/*
 * Author : Gibson, Hannah
 * Last Modified : 5/7/2024
 * Controls enemies health and movement
 */
public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;

    public float health;

    public float dmgAmount;

    public float duration = 1f;

    public float dmgThisFrame;

    HealthBar healthBar;

    private void Start()
    {
        health = maxHealth;
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.UpdateHealthBar(health, maxHealth);
    }
    /// <summary>
    /// starts the coroutine to take damage
    /// </summary>
    public void TakeDamage()
    {
        StartCoroutine(DamageOverTime());

    }
    /// <summary>
    /// controls if the enemies die when the reach 0 health.
    /// </summary>
    public void Die()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// starts a coroutine that does damage over a certain period of seconds
    /// can be changed as necessary in the inspector
    /// </summary>
    /// <returns></returns>
    private IEnumerator DamageOverTime()
    {
        float dmgPerSecond = dmgAmount/duration;

        float TimePassed = 0f;

        while(TimePassed < duration)
        {
            dmgThisFrame = dmgPerSecond * Time.deltaTime; 

            health -= dmgThisFrame;
            healthBar.UpdateHealthBar(health, maxHealth);

            if(health<= 0)
            {
                Die();
            }

            TimePassed += Time.deltaTime;

            if (TimePassed >= 5f)
            {
                yield break; 
            }

            yield return null;
        }
    }
}
