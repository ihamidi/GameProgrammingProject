using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FirstBoss : MonoBehaviour
{
    public static float currentHealth = 1f;
    public GameObject door;
    public GameObject block;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet") {
            Damage(10);
        }
    }

    public void Damage(int damageVal)
    {
        // convert damageVal into percentage
        float damagePct = (float)damageVal / 100;
        currentHealth -= damagePct;

        if (currentHealth <= 0)
        {
            block.SetActive(false);
            door.SetActive(true);
            Destroy(gameObject);
        }
    }

}
