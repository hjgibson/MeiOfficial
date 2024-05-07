using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Author : Gibson, Hannah
 * Last Modified : 5/7/2024
 * Controls the health bar above the enemies head to showcase health amounts
 */
public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    /// <summary>
    /// updates the health slider for the enemies health 
    /// </summary>
    /// <param name="currentValueHealth">current health of the enemies </param>
    /// <param name="maxValueHealth"> maximum health of the enemies</param>
    public void UpdateHealthBar (float currentValueHealth,float maxValueHealth)
    {
        healthSlider.value = currentValueHealth / maxValueHealth;
    }


}
