using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FirstBoss : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    // action event for when the current health is changed, assigned to empty delegate so exception is not thrown
    public event Action<float> OnHealthPctChanged = delegate { };

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet") {
            Dammage(10);
        }
    }

    public void Damage(int damageVal)
    {
        currentHealth -= damageVal;
        // figures out current health percent
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
