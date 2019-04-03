using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{ 
    public int maxHealth = 100;
    public int currentHealth;

    // action event for when the current health is changed, assigned to empty delegate so exception is not thrown
    public event Action<float> OnHealthPctChanged = delegate { };

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int damageVal)
    {
        currentHealth -= damageVal;
        // figures out current health percent
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
