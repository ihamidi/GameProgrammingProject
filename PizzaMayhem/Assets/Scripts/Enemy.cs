using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy : MonoBehaviour
{ 
    public static float currentHealth = 20;

    public void Damage(int damageVal)
    {
        currentHealth -= damageVal;
        
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
