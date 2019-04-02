using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{ 
    public int maxHealth = 10;
    public int currentHealth;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int damageVal)
    {
        currentHealth -= damageVal;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealth);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
