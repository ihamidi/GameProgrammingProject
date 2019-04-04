using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{ 
    public static float currentHealth = .25f;

    public void Damage(int damageVal)
    {
        // convert damageVal into percentage
        float damagePct = (float) damageVal / 100;
        currentHealth -= damagePct;
        
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
