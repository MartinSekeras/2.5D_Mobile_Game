using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    /* References our slider component on health bar */
    public Slider healthSlider;
    
    /* A function that is called from player controller. 
     * Sets current slider value to represent our health in health bar. */
    public void setHealth(int health)
    {
        //When called it sets slider value to equal our health.
        healthSlider.value = health;
    }
    
}
